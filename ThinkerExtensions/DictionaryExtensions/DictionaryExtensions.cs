using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ThinkerExtensions.DictionaryExtensions
{
    /// <summary>
    /// Provides extensions methods for <see cref="Dictionary{TKey,TValue}"/>
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Increase the value for a given key by the specified amount (default 1)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary">Dictionary to increment in</param>
        /// <param name="key">Key whose value will be incremented</param>
        /// <param name="amount"></param>
        public static void Increment<T>(this Dictionary<T, int> dictionary, T key, int amount = 1)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, 0);

            dictionary[key] += amount;
        }
    }
}
