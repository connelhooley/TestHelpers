using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace ConnelHooley.TestHelpers.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T ChooseRandomItem<T>(this IEnumerable<T> @this) =>
            TestHelper.ChooseRandomItem(@this);
    }
}