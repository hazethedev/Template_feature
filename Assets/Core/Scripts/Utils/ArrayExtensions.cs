using System;
using System.Collections.Generic;
using System.Linq;

namespace hazethedev.Extensions
{
    public static partial class ArrayExtensions
    {
        public static T Find<T>(this IEnumerable<T> array, Predicate<T> predicate)
        {
            foreach (var item in array)
            {
                if (predicate.Invoke(item))
                {
                    return item;
                }
            }

            return default;
        }

        public static bool Contains<T>(this IEnumerable<T> array, T item)
        {
            return Enumerable.Contains(array, item);
        }
    }
}
