using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsExtensions
{
    /// <summary>
    /// Provides static methods for operations on IEnumerable
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Get every consecutive pair of elements from the original sequence
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> AdjacentPairs<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, TResult> selector)
        {
            var sourcesList = source as IList<TSource> ?? source.ToList();
            return sourcesList.Zip(sourcesList.Skip(1), selector);
        }
    }
}
