using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharsAndStrings
{
    /// <summary>
    /// Provides extension methods for <see cref="string"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified string is null or an <see cref="string.Empty"/> string
        /// </summary>
        /// <param name="value">String to check</param>
        /// <returns>True if null or <see cref="string.Empty"/>, False otherwise</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
