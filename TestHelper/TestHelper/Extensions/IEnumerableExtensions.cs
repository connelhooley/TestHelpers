// ReSharper disable InconsistentNaming

using System.Collections.Generic;

namespace ConnelHooley.TestHelper.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T ChooseRandomItem<T>(this IEnumerable<T> @this) =>
            TestHelper.ChooseRandomItem(@this);
    }
}