using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ThinkerExtensions.MathExtensions.Combinatorics
{
        /// <summary>
        /// Provides enumeration over every permutation of a sequence
        /// </summary>
        /// <typeparam name="T">Type of the elements in the permutations</typeparam>
        /// <remarks>Supports permutations with repetition</remarks>
        public class Permutations<T> : IEnumerable<List<T>>
        //inspired by Scala library permutations
        {
            private readonly List<T> elements;
            private readonly List<int> indexes = new List<int>();
            private bool hasNext;

            /// <summary>
            /// Construct a class which is capable of permuting a sequence
            /// </summary>
            /// <param name="toPermute">Sequence which will be permuted by the class</param>
            public Permutations(IEnumerable<T> toPermute)
            {
                var permuteList = toPermute as IList<T> ?? toPermute.ToList();
                elements = new List<T>(permuteList);
                hasNext = true;
                Dictionary<T, int> indexConstructor = new Dictionary<T, int>();
                foreach (var element in permuteList)
                {
                    if (!indexConstructor.ContainsKey(element))
                    {
                        indexConstructor.Add(element, indexConstructor.Count);
                    }
                    indexes.Add(indexConstructor[element]);
                }
            }

            private void Swap(int index1, int index2)
            {
                T tempElement = elements[index1];
                elements[index1] = elements[index2];
                elements[index2] = tempElement;

                int tempI = indexes[index1];
                indexes[index1] = indexes[index2];
                indexes[index2] = tempI;
            }

            /// <summary>
            /// Retrieve an enumerator over all permutations
            /// </summary>
            /// <returns></returns>
            public IEnumerator<List<T>> GetEnumerator()
            {
                while (hasNext)
                {
                    yield return elements;
                    int i = indexes.Count - 2;
                    while (i >= 0 && indexes[i] >= indexes[i + 1])
                    { i--; }
                    if (i < 0)
                    { hasNext = false; }
                    else
                    {
                        int j = indexes.Count - 1;
                        while (indexes[j] <= indexes[i])
                        { j--; }
                        Swap(i, j);
                        int len = (indexes.Count - i) / 2;
                        int k = 1;
                        while (k <= len)
                        {
                            Swap(i + k, indexes.Count - k);
                            k++;
                        }
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }    
}
