using System.Collections.Generic;

namespace ConnelHooley.TestHelpers.Extensions
{
    public static class ListExtensions
    {
        public static T TakeRandomItem<T>(this List<T> @this) =>
            TestHelper.TakeRandomItem(@this);
    }
}