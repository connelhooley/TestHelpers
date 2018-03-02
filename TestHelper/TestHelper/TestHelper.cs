using System;
using System.Collections.Generic;

namespace ConnelHooley.TestHelper
{
    public static class TestHelper
    {
        public const string AlphabetLower = TestHelperContext.AlphabetLower;
        public const string AlphabetUpper = TestHelperContext.AlphabetLower;
        public const string Numbers = TestHelperContext.Numbers;
        public const string AlphaNumeric = TestHelperContext.AlphaNumeric;
        public const string SpecialChars = TestHelperContext.SpecialChars;
        
        private static readonly TestHelperContext Context = new TestHelperContext();
        
        public static T Generate<T>() => Context.Generate<T>();

        public static Exception GenerateException() =>
            Context.GenerateException();

        public static bool GenerateBool() =>
            Context.GenerateBool();

        public static DateTime GenerateDateTime() =>
            Context.GenerateDateTime();

        public static DateTime GenerateDateTimeByWeekDay(DayOfWeek dayOfWeek) =>
            Context.GenerateDateTimeByWeekDay(dayOfWeek);

        public static int GenerateNumber() =>
            Context.GenerateNumber();

        public static int GenerateNumberBelow(int value) =>
            Context.GenerateNumberBelow(value);

        public static int GenerateNumberAbove(int value) =>
            Context.GenerateNumberAbove(value);

        public static int GenerateNumberBetween(int min, int max) =>
            Context.GenerateNumberBetween(min, max);

        public static T ChooseRandomItem<T>(IEnumerable<T> items) =>
            Context.ChooseRandomItem<T>(items);

        public static T TakeRandomItem<T>(List<T> items) =>
            Context.TakeRandomItem<T>(items);

        public static string RandomCaseString(string value) =>
            Context.RandomCaseString(value);

        public static string GenerateString() =>
            Context.GenerateString();

        public static string GenerateStringFrom(string chars) =>
            Context.GenerateStringFrom(chars);

        public static string GenerateWhitespaceString() =>
            Context.GenerateWhitespaceString();

        public static IEnumerable<T> GenerateMany<T>(Func<T> creator) =>
            Context.GenerateMany(creator);

        public static IEnumerable<T> GenerateMany<T>(int count, Func<T> creator) =>
            Context.GenerateMany(count, creator);

        public static T GenerateEnum<T>(params T[] valuesToExclude) =>
            Context.GenerateEnum(valuesToExclude);
    }
}   
