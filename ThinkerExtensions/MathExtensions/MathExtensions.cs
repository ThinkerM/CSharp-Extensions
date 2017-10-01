using System;

namespace ThinkerExtensions.MathExtensions
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
            return Double.IsNaN(value);
        }

        /// <summary>
        /// Raises the number to a specified power
        /// </summary>
        /// <param name="value">Number to raise</param>
        /// <param name="power">Power to raise to</param>
        /// <returns>Specified value raised to the specified power</returns>
        public static double Power(this int value, double power)
        {
            return Math.Pow(value, power);
        }

        /// <summary>
        /// Raises the number to a specified power
        /// </summary>
        /// <param name="value">Number to raise</param>
        /// <param name="power">Power to raise to</param>
        /// <returns>Specified value raised to the specified power</returns>
        public static double Power(this double value, double power)
        {
            return Math.Pow(value, power);
        }

        /// <summary>
        /// Rounds the value to a specified number of fractional digits
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static double Round(this double value, int decimalPlaces)
        {
            return Math.Round(value, decimalPlaces);
        }

        /// <summary>
        /// Rounds the value to a specified number of fractional digits
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static decimal Round(this decimal value, int decimalPlaces)
        {
            return Math.Round(value, decimalPlaces);
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
    }
}
