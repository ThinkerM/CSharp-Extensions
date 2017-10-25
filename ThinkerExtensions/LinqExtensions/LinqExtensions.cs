using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkerExtensions.LinqExtensions
{
    /// <summary>
    /// Provides extension methods with the behaviour of LINQ methods
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Partition the source into batches of specified size (or smaller if not enough elements remain for a batch)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="batchSize">Number of elements to appear in each batch (less if not enough elements remain)</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(
            this IEnumerable<T> source, int batchSize)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    yield return YieldBatchElements(enumerator, batchSize - 1);
            }
        }

        private static IEnumerable<T> YieldBatchElements<T>(
            IEnumerator<T> source, int batchSize)
        {
            yield return source.Current;
            for (int i = 0; i < batchSize && source.MoveNext(); i++)
                yield return source.Current;
        }
    }
}
