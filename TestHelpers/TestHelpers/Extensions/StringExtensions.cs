namespace ConnelHooley.TestHelpers.Extensions
{
    public static class StringExtensions
    {
        public static string ToRandomCase(this string @this) => 
            TestHelper.RandomCaseString(@this);
    
        public static string WrapStringInWhitespace(this string @this) =>
            TestHelper.WrapStringInWhitespace(@this);
    }
}