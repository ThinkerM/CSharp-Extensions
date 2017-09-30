using System.Collections;
using System.Linq;

namespace NumericalExtensions
{
    /// <summary>
    /// Provides extensions methods which already exist for <see cref="IEnumerable"/> 
    /// for small groups of numerical values without the need to construct an enumerable structure from them
    /// </summary>
    public static class SmallGroupsExtensions {
        /// <summary>
        /// Arithmetic mean of two values
        /// </summary>
        /// <param name="value1">First value to compute mean from</param>
        /// <param name="value2">Second value to compute mean from</param>
        /// <returns>Mean of both values</returns>
        public static double Mean(this double value1, double value2)
        {
            return (value1 + value2) / 2;
        }

        /// <summary>
        /// Arithmetic mean of two values
        /// </summary>
        /// <param name="value1">First value to compute mean from</param>
        /// <param name="value2">Second value to compute mean from</param>
        /// <returns>Mean of both values</returns>
        public static double Mean(this int value1, int value2)
        {
            return (value1 + value2) / 2;
        }

        /// <summary>
        /// Arithmetic mean of two values
        /// </summary>
        /// <param name="value1">First value to compute mean from</param>
        /// <param name="value2">Second value to compute mean from</param>
        /// <returns>Mean of both values</returns>
        public static byte Mean(this byte value1, byte value2)
        {
            return (byte)((value1 + value2) / 2);
        }

        /// <summary>
        /// Get a maximum of 3 values
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <returns></returns>
        public static int Max(int value1, int value2, int value3)
        {
            return new[] { value1, value2, value3 }.Max();
        }

        /// <summary>
        /// Get a maximum of three values
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <returns></returns>
        public static double Max(double value1, double value2, double value3)
        {
            return new[] { value1, value2, value3 }.Max();
        }
    }
}