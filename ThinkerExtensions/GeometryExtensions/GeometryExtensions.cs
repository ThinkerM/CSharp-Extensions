using System;
using System.Drawing;

namespace ThinkerExtensions.GeometryExtensions
{
    /// <summary>
    /// Provides methods for handling geometry-related problems
    /// </summary>
    public static class GeometryExtensions
    {
        /// <summary>
        /// Convert value in radians to degrees
        /// </summary>
        /// <param name="radians">Value in radians to convert</param>
        /// <returns>Degrees value</returns>
        public static int ToDegrees(this double radians)
        {
            return (int)Math.Round(radians * 180 / Math.PI);
        }

        /// <summary>
        /// Convert value in degrees to radians
        /// </summary>
        /// <param name="degrees">Value in degrees to convert</param>
        /// <returns>Value in radians</returns>
        public static double ToRadians(this int degrees)
        {
            return degrees * Math.PI / 180;
        }

        /// <summary>
        /// Distance to another point on a 2D plane
        /// </summary>
        /// <param name="origin">Point of origin, this point</param>
        /// <param name="other">Point to get distance to</param>
        /// <returns>Distance between this and another point</returns>
        public static double DistanceTo(this Point origin, Point other)
        {
            return Math.Sqrt(
                Math.Pow(origin.X - other.X, 2) + Math.Pow(origin.Y - other.Y, 2));
        }      
    }
}
