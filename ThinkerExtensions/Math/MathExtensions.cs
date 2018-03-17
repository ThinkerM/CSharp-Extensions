using System;

namespace ThinkerExtensions.Math
{
    /// <summary>
    /// Provides additional methods related to number manipulation
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// Checks whether the specified value is not a number (double.NaN)
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if value is double.NaN, False otherwise</returns>
        public static bool IsNaN(this double value)
        {
            return double.IsNaN(value);
        }

        /// <summary>
        /// Raises the number to a specified power
        /// </summary>
        /// <param name="value">Number to raise</param>
        /// <param name="power">Power to raise to</param>
        /// <returns>Specified value raised to the specified power</returns>
        public static double Power(this int value, double power)
        {
            return System.Math.Pow(value, power);
        }

        /// <summary>
        /// Raises the number to a specified power
        /// </summary>
        /// <param name="value">Number to raise</param>
        /// <param name="power">Power to raise to</param>
        /// <returns>Specified value raised to the specified power</returns>
        public static double Power(this double value, double power)
        {
            return System.Math.Pow(value, power);
        }

        /// <summary>
        /// Rounds the value to a specified number of fractional digits
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static double Round(this double value, int decimalPlaces)
        {
            return System.Math.Round(value, decimalPlaces);
        }

        /// <summary>
        /// Rounds the value to a specified number of fractional digits
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static decimal Round(this decimal value, int decimalPlaces)
        {
            return System.Math.Round(value, decimalPlaces);
        }

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
            return (double)(value1 + value2) / 2;
        }

        /// <summary>
        /// Determine if number is prime
        /// </summary>
        /// <param name="value">Number to check for prime-ness</param>
        /// <returns>True if value is prime, False otherwise</returns>
        public static bool IsPrime(this int value)
        {
            long longValue = value;
            return longValue.IsPrime();
        }

        /// <summary>
        /// Determine if number is prime
        /// </summary>
        /// <param name="value">Number to check for prime-ness</param>
        /// <returns>True if value is prime, False otherwise</returns>
        public static bool IsPrime(this long value)
        {
            if (value <= 0) return false;
            if (value == 1) return false;
            if (value == 2) return true;
            if (value % 2 == 0) return false;

            int boundary = (int)System.Math.Ceiling(System.Math.Sqrt(value));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (value % i == 0) return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if the item is within the boundaries of two other items (inclusive bounds)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween<T>(this T item, T left, T right)
            where T : IComparable<T>
        {
            return (item.CompareTo(left) >= 0 && item.CompareTo(right) <= 0)
                   ||
                   (item.CompareTo(left) <= 0 && item.CompareTo(right) >= 0);
        }

        /// <summary>
        /// Determines if the item is within the exlusive bounds of two other items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetweenExclusive<T>(this T item, T left, T right)
            where T : IComparable<T>
        {
            return (item.CompareTo(left) > 0 && item.CompareTo(right) < 0)
                   ||
                   (item.CompareTo(left) < 0 && item.CompareTo(right) > 0);
        }
    }
}
