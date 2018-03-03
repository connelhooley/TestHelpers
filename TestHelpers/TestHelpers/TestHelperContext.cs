using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoFixture;
using ConnelHooley.TestHelpers.Abstractions;

namespace ConnelHooley.TestHelpers
{
    internal sealed class TestHelperContext : ITestHelperContext
    {
        public const string AlphabetLower = "abcdefghijklmnopqrstuvwxyz";
        public const string AlphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Numbers = "0123456789";
        public const string AlphaNumeric = AlphabetLower + AlphabetUpper + Numbers;
        public const string SpecialChars = "!\"£$%^&*()_+=-{}][:';'<>?,./|\\";

        private readonly Fixture _fixture;
        private readonly Random _random;

        public TestHelperContext()
        {
            _random = new Random();
            _fixture = new Fixture();

            Register(GenerateBool);
            Register(GenerateString);
            Register(GenerateException);
            Register(GenerateDateTime);
            Register(GenerateNumber);

            foreach (var configurator in TypeInstantiator.InstantiateAll<ITestHelperConfigurator>())
            {
                configurator.Configure(this);
            }
        }

        public void Register<T>(Func<T> creator) => _fixture.Register(creator);
        
        public T Generate<T>() => _fixture.Create<T>();

        public Exception GenerateException() =>
           new Exception(GenerateString());

        public bool GenerateBool() =>
            _random.NextDouble() >= 0.5;

        public DateTime GenerateDateTime() =>
            DateTime.Today.AddDays(GenerateNumberBetween(-1000, 1000));

        public DateTime GenerateDateTimeByWeekDay(DayOfWeek dayOfWeek)
        {
            var result = GenerateDateTime();
            while (result.DayOfWeek != dayOfWeek)
            {
                result = result.AddDays(1);
            }
            return result;
        }

        public int GenerateNumber() =>
            _random.Next();

        public int GenerateNumberBelow(int value) =>
            _random.Next(int.MinValue, value);

        public int GenerateNumberAbove(int value) =>
            _random.Next(value + 1, int.MaxValue);

        public int GenerateNumberBetween(int min, int max) =>
            _random.Next(min, max + 1);

        public T ChooseRandomItem<T>(IEnumerable<T> items)
        {
            var list = items as List<T> ?? items.ToList();
            var index = _random.Next(list.Count);
            return list[index];
        }

        public T TakeRandomItem<T>(List<T> items)
        {
            var index = _random.Next(items.Count);
            var result = items[index];
            items.Remove(result);
            return result;
        }

        public string RandomCaseString(string value) =>
            value.Aggregate(
                string.Empty,
                (result, letter) =>
                    result + (GenerateBool()
                        ? letter.ToString().ToUpperInvariant()
                        : letter.ToString().ToLowerInvariant()));

        public string GenerateString() =>
            GenerateStringFrom(AlphaNumeric + SpecialChars);

        public string GenerateStringFrom(string chars) =>
            string.Join(
                string.Empty,
                Enumerable
                    .Repeat(0, GenerateNumberBetween(1, 50))
                    .Select(i => ChooseRandomItem(chars)));

        public string GenerateWhitespaceString() =>
            string.Join(
                string.Empty,
                Enumerable.Repeat(" ", GenerateNumberBetween(1, 50)));
        
        public string WrapStringInWhitespace(string value) =>
            GenerateWhitespaceString() +
            value +
            GenerateWhitespaceString();

        public IEnumerable<T> GenerateMany<T>(Func<T> creator) =>
            Enumerable
                .Range(1, _random.Next(2, 101))
                .Select(i => creator());

        public IEnumerable<T> GenerateMany<T>(int count, Func<T> creator) =>
            Enumerable
                .Range(1, count)
                .Select(i => creator());

        public T GenerateEnum<T>(params T[] valuesToExclude)
        {
            if (!typeof(T).GetTypeInfo().IsEnum) throw new InvalidOperationException("Not an enum");
            var distinctEnumeratorToExclude = valuesToExclude
                .Distinct()
                .ToList();
            var values = Enum.GetValues(typeof(T));
            if (distinctEnumeratorToExclude.Count == values.Length) throw new InvalidOperationException("Cannot exclude all enum values");
            while (true)
            {
                var randomItem = (T)values.GetValue(_random.Next(values.Length));
                if (!distinctEnumeratorToExclude.Contains(randomItem))
                {
                    return randomItem;
                }
            }
        }

        public Guid GenerateGuid() => 
            Guid.NewGuid();

        public Func<Type> GetRandomTypeGenerator()
        {
            var types = Assembly
                .GetAssembly(typeof(Type))
                .GetExportedTypes()
                .ToList();
            return () => TakeRandomItem(types);
        }
    }
}