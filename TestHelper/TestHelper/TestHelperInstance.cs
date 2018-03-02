using System;
using System.Collections.Generic;
using ConnelHooley.TestHelper.Abstractions;

namespace ConnelHooley.TestHelper
{
    public sealed class TestHelperInstance
    {
        public const string AlphabetLower = TestHelperContext.AlphabetLower;
        public const string AlphabetUpper = TestHelperContext.AlphabetLower;
        public const string Numbers = TestHelperContext.Numbers;
        public const string AlphaNumeric = TestHelperContext.AlphaNumeric;
        public const string SpecialChars = TestHelperContext.SpecialChars;

        private readonly TestHelperContext _context;

        public TestHelperInstance(Action<ITestHelperContext> configInstance)
        {
            _context = new TestHelperContext();
            configInstance(_context);
        }

        public T Generate<T>() => _context.Generate<T>();

        public Exception GenerateException() => 
            _context.GenerateException();

        public bool GenerateBool() => 
            _context.GenerateBool();

        public DateTime GenerateDateTime() =>
            _context.GenerateDateTime();

        public DateTime GenerateDateTimeByWeekDay(DayOfWeek dayOfWeek) =>
            _context.GenerateDateTimeByWeekDay(dayOfWeek);

        public int GenerateNumber() =>
            _context.GenerateNumber();

        public int GenerateNumberBelow(int value) =>
            _context.GenerateNumberBelow(value);

        public int GenerateNumberAbove(int value) =>
            _context.GenerateNumberAbove(value);

        public int GenerateNumberBetween(int min, int max) =>
            _context.GenerateNumberBetween(min, max);

        public T ChooseRandomItem<T>(IEnumerable<T> items) =>
            _context.ChooseRandomItem<T>(items);

        public T TakeRandomItem<T>(List<T> items) =>
            _context.TakeRandomItem<T>(items);

        public string RandomCaseString(string value) =>
            _context.RandomCaseString(value);

        public string GenerateString() =>
            _context.GenerateString();

        public string GenerateStringFrom(string chars) =>
            _context.GenerateStringFrom(chars);

        public string GenerateWhitespaceString() =>
            _context.GenerateWhitespaceString();

        public string WrapStringInWhitespace(string value) =>
            _context.WrapStringInWhitespace(value);

        public IEnumerable<T> GenerateMany<T>(Func<T> creator) =>
            _context.GenerateMany(creator);

        public IEnumerable<T> GenerateMany<T>(int count, Func<T> creator) =>
            _context.GenerateMany(count, creator);

        public T GenerateEnum<T>(params T[] valuesToExclude) =>
            _context.GenerateEnum(valuesToExclude);
    }
}   
