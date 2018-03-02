namespace ConnelHooley.TestHelper.Extensions
{
    public static class StringExtensions
    {
        public static string ToRandomCase(this string @this) => 
            TestHelper.RandomCaseString(@this);
    }
}