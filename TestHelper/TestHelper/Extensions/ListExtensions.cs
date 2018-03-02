using System.Collections.Generic;

namespace ConnelHooley.TestHelper.Extensions
{
    public static class ListExtensions
    {
        public static T ChooseRandomItem<T>(this List<T> @this) =>
            TestHelper.ChooseRandomItem(@this);
    }
}