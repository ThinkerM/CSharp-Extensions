using System;
using System.Drawing;

namespace GeometryExtensions
{
    /// <summary>
    /// Provides methods for handling geometry-related problems
    /// </summary>
    public static class GeometryExtensions
    {
        /// <summary>
        /// Convert a value in radians to degrees
        /// </summary>
        /// <param name="radians">Value in radians to convert</param>
        /// <returns>Degrees values</returns>
        public static int RadiansToDegrees(double radians)
        {
            return (int)(radians * 180 / Math.PI);
        }

        /// <summary>
        /// Convert value in radians to degrees
        /// </summary>
        /// <param name="radians">Value in radians to convert</param>
        /// <returns>Degrees value</returns>
        public static int ToDegrees(this double radians)
        {
            return (int)(radians * 180 / Math.PI);
        }

        /// <summary>
        /// Convert a value in degrees to radians
        /// </summary>
        /// <param name="degrees">Value in degrees to convert</param>
        /// <returns>Radians value</returns>
        public static double DegreesToRadians(int degrees)
        {
            return degrees * Math.PI / 180;
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
        /// Distance between two points on a 2D plane
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <returns>Euclidean distance between two points</returns>
        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(
                Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
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

        /// <summary>
        /// Calculate location of a point from an angle and distance relative to another point
        /// </summary>
        /// <param name="origin">Point to which the angle and distance relate</param>
        /// <param name="angle">Angle relative to origin</param>
        /// <param name="distance">Distance relative to origin</param>
        /// <returns></returns>
        public static Point GetCoordinates(Point origin, Angle angle, double distance)
        {
            int x = (int)(distance * Math.Cos(angle.Radians));
            int y = (int)(distance * Math.Sin(angle.Radians));
            return new Point(x + origin.X, y + origin.Y);
        }

        /// <summary>
        /// Gives a distance between two points without square-rooting them
        /// </summary>
        /// <param name="point"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static double SquaredDistanceTo(this Point point, Point point2)
        {
            return (point2.X - point.X) * (point2.X - point.X) + (point2.Y - point.Y) * (point2.Y - point.Y);
        }        
    }
}
