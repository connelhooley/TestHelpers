using System;
using System.Collections.Generic;

namespace ConnelHooley.TestHelpers
{
    public static class TestHelper
    {
        public const string AlphabetLower = TestHelperContext.AlphabetLower;
        public const string AlphabetUpper = TestHelperContext.AlphabetLower;
        public const string Numbers = TestHelperContext.Numbers;
        public const string AlphaNumeric = TestHelperContext.AlphaNumeric;
        public const string SpecialChars = TestHelperContext.SpecialChars;
        
        private static readonly TestHelperContext Context = new TestHelperContext();

        /// <summary>
        /// Returns an object created by AutoFixture
        /// </summary>
        /// <returns></returns>
        public static T Generate<T>() => Context.Generate<T>();

        /// <summary>
        /// Returns an exception with a randomly generated message.
        /// </summary>
        public static Exception GenerateException() =>
            Context.GenerateException();

        /// <summary>
        /// Returns a random boolean.
        /// </summary>
        public static bool GenerateBool() =>
            Context.GenerateBool();

        /// <summary>
        /// Returns a random date between 1000 days in the past and 1000 days in the future.
        /// </summary>
        public static DateTime GenerateDateTime() =>
            Context.GenerateDateTime();

        /// <summary>
        /// Returns a random date between 1000 days in the past and 1007 days in the future on a certain day.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week that should be generated.</param>
        public static DateTime GenerateDateTimeByWeekDay(DayOfWeek dayOfWeek) =>
            Context.GenerateDateTimeByWeekDay(dayOfWeek);

        /// <summary>
        /// Returns a random number. Includes negative values.
        /// </summary>
        public static int GenerateNumber() =>
            Context.GenerateNumber();

        /// <summary>
        /// Returns a random number below a certain value. Includes negative values.
        /// </summary>
        /// <param name="value">The number that the generated number should be below. The exclusive upper bound.</param>`
        public static int GenerateNumberBelow(int value) =>
            Context.GenerateNumberBelow(value);

        /// <summary>
        /// Returns a random number above a certain value. Includes negative values.
        /// </summary>
        /// <param name="value">The number that the generated number should be above. The exclusive lower bound.</param>`
        public static int GenerateNumberAbove(int value) =>
            Context.GenerateNumberAbove(value);

        /// <summary>
        /// Returns a random number between two values.
        /// </summary>
        /// <param name="min">The number that the generated number should be greater than or equal to. The inclusive lower bound.</param>
        /// <param name="max">The number that the generated number should be less than or equal to. The inclusive upper bound.</param>
        public static int GenerateNumberBetween(int min, int max) =>
            Context.GenerateNumberBetween(min, max);

        /// <summary>
        /// Returns a random item from an IEnumerable.
        /// </summary>
        /// <param name="items">The items to choose from.</param>
        public static T ChooseRandomItem<T>(IEnumerable<T> items) =>
            Context.ChooseRandomItem(items);

        /// <summary>
        /// Removes a random item from a List and returns the removed item.
        /// </summary>
        /// <param name="items">The items to take from.</param>
        public static T TakeRandomItem<T>(List<T> items) =>
            Context.TakeRandomItem(items);

        /// <summary>
        /// Randomly mix-cases a string so that some of its letters are uppercase and some are lowercase.
        /// </summary>
        /// <param name="value">The string to randomly mix-case</param>
        public static string RandomCaseString(string value) =>
            Context.RandomCaseString(value);

        /// <summary>
        /// Returns a random string made up of letters from the alphabet (uppercase and lowercase), numbers and some special characters.
        /// </summary>
        public static string GenerateString() =>
            Context.GenerateString();

        /// <summary>
        /// Returns a random string made up of the chars in the given string.
        /// </summary>
        /// <param name="chars">The chars to generate the string from.</param>
        public static string GenerateStringFrom(string chars) =>
            Context.GenerateStringFrom(chars);

        /// <summary>
        /// Returns a string containing 1 to 50 spaces.
        /// </summary>
        public static string GenerateWhitespaceString() =>
            Context.GenerateWhitespaceString();

        /// <summary>
        /// Returns the given string with 1 to 50 spaces prepended and appended to it.
        /// </summary>
        /// <param name="value">The value to wrap in whitespace.</param>
        public static string WrapStringInWhitespace(string value) =>
            Context.WrapStringInWhitespace(value);

        /// <summary>
        /// Runs the creator function between 2 and 100 times and returns the results in an IEnummerable.
        /// </summary>
        /// <param name="creator">The creator function that is called many times.</param>
        public static IEnumerable<T> GenerateMany<T>(Func<T> creator) =>
            Context.GenerateMany(creator);

        /// <summary>
        /// Runs the creator function the specified number of times and returns the results in an IEnummerable.
        /// </summary>
        /// <param name="count">The number of times to call the creator function.</param>
        /// <param name="creator">The creator function that is called the specified amount of times.</param>
        public static IEnumerable<T> GenerateMany<T>(int count, Func<T> creator) =>
            Context.GenerateMany(count, creator);

        /// <summary>
        /// Returns a random enum.
        /// </summary>
        /// <param name="valuesToExclude">Values to exclude from being returned.</param>
        public static T GenerateEnum<T>(params T[] valuesToExclude) =>
            Context.GenerateEnum(valuesToExclude);
        
        /// <summary>
        /// Returns a function that randomly selects a Type from the System namespace.
        /// </summary>
        public static Func<Type> GetRandomTypeGenerator() =>
            Context.GetRandomTypeGenerator();
    }
}   
