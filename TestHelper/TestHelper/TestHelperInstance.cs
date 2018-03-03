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

        /// <summary>
        /// Returns an object created by AutoFixture
        /// </summary>
        /// <returns></returns>
        public T Generate<T>() => _context.Generate<T>();

        /// <summary>
        /// Returns an exception with a randomly generated message.
        /// </summary>
        public Exception GenerateException() => 
            _context.GenerateException();

        /// <summary>
        /// Returns a random boolean.
        /// </summary>
        public bool GenerateBool() => 
            _context.GenerateBool();

        /// <summary>
        /// Returns a random date between 1000 days in the past and 1000 days in the future.
        /// </summary>
        public DateTime GenerateDateTime() =>
            _context.GenerateDateTime();

        /// <summary>
        /// Returns a random date between 1000 days in the past and 1007 days in the future on a certain day.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week that should be generated.</param>
        public DateTime GenerateDateTimeByWeekDay(DayOfWeek dayOfWeek) =>
            _context.GenerateDateTimeByWeekDay(dayOfWeek);

        /// <summary>
        /// Returns a random number. Includes negative values.
        /// </summary>
        public int GenerateNumber() =>
            _context.GenerateNumber();

        /// <summary>
        /// Returns a random number below a certain value. Includes negative values.
        /// </summary>
        /// <param name="value">The number that the generated number should be below. The exclusive upper bound.</param>`
        public int GenerateNumberBelow(int value) =>
            _context.GenerateNumberBelow(value);

        /// <summary>
        /// Returns a random number above a certain value. Includes negative values.
        /// </summary>
        /// <param name="value">The number that the generated number should be above. The exclusive lower bound.</param>`
        public int GenerateNumberAbove(int value) =>
            _context.GenerateNumberAbove(value);

        /// <summary>
        /// Returns a random number between two values.
        /// </summary>
        /// <param name="min">The number that the generated number should be greater than or equal to. The inclusive lower bound.</param>
        /// <param name="max">The number that the generated number should be less than or equal to. The inclusive upper bound.</param>
        public int GenerateNumberBetween(int min, int max) =>
            _context.GenerateNumberBetween(min, max);

        /// <summary>
        /// Returns a random item from an IEnumerable.
        /// </summary>
        /// <param name="items">The items to choose from.</param>
        public T ChooseRandomItem<T>(IEnumerable<T> items) =>
            _context.ChooseRandomItem(items);

        /// <summary>
        /// Removes a random item from a List and returns the removed item.
        /// </summary>
        /// <param name="items">The items to take from.</param>
        public T TakeRandomItem<T>(List<T> items) =>
            _context.TakeRandomItem(items);

        /// <summary>
        /// Randomly mix-cases a string so that some of its letters are uppercase and some are lowercase.
        /// </summary>
        /// <param name="value">The string to randomly mix-case</param>
        public string RandomCaseString(string value) =>
            _context.RandomCaseString(value);

        /// <summary>
        /// Returns a random string made up of letters from the alphabet (uppercase and lowercase), numbers and some special characters.
        /// </summary>
        public string GenerateString() =>
            _context.GenerateString();

        /// <summary>
        /// Returns a random string made up of the chars in the given string.
        /// </summary>
        /// <param name="chars">The chars to generate the string from.</param>
        public string GenerateStringFrom(string chars) =>
            _context.GenerateStringFrom(chars);

        /// <summary>
        /// Returns a string containing 1 to 50 spaces.
        /// </summary>
        public string GenerateWhitespaceString() =>
            _context.GenerateWhitespaceString();

        /// <summary>
        /// Returns the given string with 1 to 50 spaces prepended and appended to it.
        /// </summary>
        /// <param name="value">The value to wrap in whitespace.</param>
        public string WrapStringInWhitespace(string value) =>
            _context.WrapStringInWhitespace(value);

        /// <summary>
        /// Runs the creator function between 2 and 100 times and returns the results in an IEnummerable.
        /// </summary>
        /// <param name="creator">The creator function that is called many times.</param>
        public IEnumerable<T> GenerateMany<T>(Func<T> creator) =>
            _context.GenerateMany(creator);

        /// <summary>
        /// Runs the creator function the specified number of times and returns the results in an IEnummerable.
        /// </summary>
        /// <param name="count">The number of times to call the creator function.</param>
        /// <param name="creator">The creator function that is called the specified amount of times.</param>
        public IEnumerable<T> GenerateMany<T>(int count, Func<T> creator) =>
            _context.GenerateMany(count, creator);

        /// <summary>
        /// Returns a random enum.
        /// </summary>
        /// <param name="valuesToExclude">Values to exclude from being returned.</param>
        public T GenerateEnum<T>(params T[] valuesToExclude) =>
            _context.GenerateEnum(valuesToExclude);
        
        /// <summary>
        /// Returns a function that randomly selects a Type from the System namespace.
        /// </summary>
        public Func<Type> GetRandomTypeGenerator() =>
            _context.GetRandomTypeGenerator();
    }
}   
