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
        /// Raises the number to a specified power
        /// </summary>
        /// <param name="value">Number to raise</param>
        /// <param name="power">Power to raise to</param>
        /// <returns>Specified value raised to the specified power</returns>
        public static double Power(this float value, double power)
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
    }
}
