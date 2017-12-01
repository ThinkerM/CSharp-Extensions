using System.Collections.Generic;
using System.Drawing;

namespace ThinkerExtensions.Geometry
{
    /// <summary>
    /// Representation of a line in 2D
    /// </summary>
    public class LineEquation
    {
        /// <summary>
        /// Construct a line representation
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public LineEquation(Point start, Point end)
        {
            Start = start;
            End = end;

            A = End.Y - Start.Y;
            B = Start.X - End.X;
            C = A * Start.X + B * Start.Y;
        }

        /// <summary>
        /// One end of the line
        /// </summary>
        public Point Start { get; }
        /// <summary>
        /// Second end point of the line
        /// </summary>
        public Point End { get; }

        /// <summary>
        /// Line equation X-slope parameter
        /// </summary>
        public double A { get; }
        /// <summary>
        /// Line equation Y-slope parameter
        /// </summary>
        public double B { get; }
        /// <summary>
        /// Line equation shift parameter
        /// </summary>
        public double C { get; }

        /// <summary>
        /// Find an intersection of two lines or null if they are parallel
        /// </summary>
        /// <param name="otherLine"></param>
        /// <returns></returns>
        public Point? GetIntersectionWithLine(LineEquation otherLine)
        {
            double determinant = A * otherLine.B - otherLine.A * B;

            if (determinant.IsZero()) //lines are parallel
                return default(Point?);

            //Cramer's Rule

            double x = (otherLine.B * C - B * otherLine.C) / determinant;
            double y = (A * otherLine.C - otherLine.A * C) / determinant;

            Point intersectionPoint = new Point((int)x, (int)y);

            return intersectionPoint;
        }

        /// <summary>
        /// Find an intersection of this line and a segment of another
        /// </summary>
        /// <param name="otherSegment"></param>
        /// <returns></returns>
        public Point? GetIntersectionWithLineSegment(LineEquation otherSegment)
        {
            Point? intersectionPoint = GetIntersectionWithLine(otherSegment);

            if (intersectionPoint.HasValue &&
                intersectionPoint.Value.IsBetweenTwoPoints(otherSegment.Start, otherSegment.End))
            { return intersectionPoint; }

            return default(Point?);
        }

        /// <summary>
        /// Find an intersection of this line's defines start-end segment and another segment
        /// </summary>
        /// <param name="otherSegment"></param>
        /// <returns></returns>
        public Point? GetSegmentIntersectionWithOtherSegment(LineEquation otherSegment)
        {
            Point? intersectionPoint = GetIntersectionWithLineSegment(otherSegment);

            if (intersectionPoint.HasValue &&
                intersectionPoint.Value.IsBetweenTwoPoints(Start, End))
            { return intersectionPoint; }

            return default(Point?);
        }

        /// <summary>
        /// String representation of segment
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "[" + Start + "], [" + End + "]";
        }
    }

    internal static class DoubleExtensions
    {
        //SOURCE: https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Precision.cs
        //        https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Precision.Equality.cs
        //        http://referencesource.microsoft.com/#WindowsBase/Shared/MS/Internal/DoubleUtil.cs
        //        http://stackoverflow.com/questions/2411392/double-epsilon-for-equality-greater-than-less-than-less-than-or-equal-to-gre

        /// <summary>
        /// The smallest positive number that when SUBTRACTED from 1D yields a result different from 1D.
        /// The value is derived from 2^(-53) = 1.1102230246251565e-16, where IEEE 754 binary64 &quot;double precision&quot; floating point numbers have a significand precision that utilize 53 bits.
        ///
        /// This number has the following properties:
        ///     (1 - NegativeMachineEpsilon) &lt; 1 and
        ///     (1 + NegativeMachineEpsilon) == 1
        /// </summary>
        public const double NEGATIVE_MACHINE_EPSILON = 1.1102230246251565e-16D; //Math.Pow(2, -53);

        /// <summary>
        /// The smallest positive number that when ADDED to 1D yields a result different from 1D.
        /// The value is derived from 2 * 2^(-53) = 2.2204460492503131e-16, where IEEE 754 binary64 &quot;double precision&quot; floating point numbers have a significand precision that utilize 53 bits.
        ///
        /// This number has the following properties:
        ///     (1 - PositiveDoublePrecision) &lt; 1 and
        ///     (1 + PositiveDoublePrecision) &gt; 1
        /// </summary>
        public const double POSITIVE_MACHINE_EPSILON = 2D * NEGATIVE_MACHINE_EPSILON;

        /// <summary>
        /// The smallest positive number that when SUBTRACTED from 1D yields a result different from 1D.
        ///
        /// This number has the following properties:
        ///     (1 - NegativeMachineEpsilon) &lt; 1 and
        ///     (1 + NegativeMachineEpsilon) == 1
        /// </summary>
        public static readonly double MeasuredNegativeMachineEpsilon = MeasureNegativeMachineEpsilon();

        private static double MeasureNegativeMachineEpsilon()
        {
            double epsilon = 1D;

            do
            {
                double nextEpsilon = epsilon / 2D;

                if (1D - nextEpsilon == 1D) //if nextEpsilon is too small
                    return epsilon;

                epsilon = nextEpsilon;
            }
            while (true);
        }

        /// <summary>
        /// The smallest positive number that when ADDED to 1D yields a result different from 1D.
        ///
        /// This number has the following properties:
        ///     (1 - PositiveDoublePrecision) &lt; 1 and
        ///     (1 + PositiveDoublePrecision) &gt; 1
        /// </summary>
        public static readonly double MeasuredPositiveMachineEpsilon = MeasurePositiveMachineEpsilon();

        private static double MeasurePositiveMachineEpsilon()
        {
            double epsilon = 1D;

            do
            {
                double nextEpsilon = epsilon / 2D;

                if (1D + nextEpsilon == 1D) //if nextEpsilon is too small
                    return epsilon;

                epsilon = nextEpsilon;
            }
            while (true);
        }

        private const double DEFAULT_DOUBLE_ACCURACY = NEGATIVE_MACHINE_EPSILON * 10D;

        public static bool IsClose(this double value1, double value2, double maximumAbsoluteError = DEFAULT_DOUBLE_ACCURACY)
        {
            if (double.IsInfinity(value1) || double.IsInfinity(value2))
                return value1 == value2;

            if (double.IsNaN(value1) || double.IsNaN(value2))
                return false;

            double delta = value1 - value2;

            if (delta > maximumAbsoluteError ||
                delta < -maximumAbsoluteError)
                return false;

            return true;
        }

        internal static bool LessThan(this double value1, double value2)
        {
            return (value1 < value2) && !IsClose(value1, value2);
        }

        internal static bool GreaterThan(this double value1, double value2)
        {
            return (value1 > value2) && !IsClose(value1, value2);
        }

        internal static bool LessThanOrClose(this double value1, double value2)
        {
            return (value1 < value2) || IsClose(value1, value2);
        }

        internal static bool GreaterThanOrClose(this double value1, double value2)
        {
            return (value1 > value2) || IsClose(value1, value2);
        }

        internal static bool IsOne(this double value)
        {
            double delta = value - 1D;

            if (delta > POSITIVE_MACHINE_EPSILON ||
                delta < -POSITIVE_MACHINE_EPSILON)
                return false;

            return true;
        }

        internal static bool IsZero(this double value)
        {
            if (value > POSITIVE_MACHINE_EPSILON ||
                value < -POSITIVE_MACHINE_EPSILON)
                return false;

            return true;
        }
    }

    /// <summary>
    /// Extension methods for working with Rectangles
    /// </summary>
    public static class RectangleExtentions
    {
        /// <summary>
        /// Evaluate whether a rectangle intersects a line(segment), give intersected segments
        /// </summary>
        /// <param name="rectangle">Rectangle to check for intersection of line</param>
        /// <returns></returns>
        public static IEnumerable<LineEquation> LineSegments(this Rectangle rectangle)
        {
            var lines = new List<LineEquation>
            {
                new LineEquation(new Point(rectangle.X, rectangle.Y),
                                 new Point(rectangle.X, rectangle.Y + rectangle.Height)),

                new LineEquation(new Point(rectangle.X, rectangle.Y + rectangle.Height),
                                 new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height)),

                new LineEquation(new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height),
                                 new Point(rectangle.X + rectangle.Width, rectangle.Y)),

                new LineEquation(new Point(rectangle.X + rectangle.Width, rectangle.Y),
                                 new Point(rectangle.X, rectangle.Y)),
            };

            return lines;
        }

        //improved from original at http://www.codeproject.com/Tips/403031/Extension-methods-for-finding-centers-of-a-rectang

        /// <summary>
        /// Returns the center point of the rectangle
        /// </summary>
        /// <param name="r"></param>
        /// <returns>Center point of the rectangle</returns>
        public static Point Center(this Rectangle r)
        {
            return new Point((int)(r.Left + (r.Width / 2D)),(int) (r.Top + (r.Height / 2D)));
        }
        /// <summary>
        /// Returns the center right point of the rectangle
        /// i.e. the right hand edge, centered vertically.
        /// </summary>
        /// <param name="r"></param>
        /// <returns>Center right point of the rectangle</returns>
        public static Point CenterRight(this Rectangle r)
        {
            return new Point((int)r.Right, (int)(r.Top + (r.Height / 2D)));
        }
        /// <summary>
        /// Returns the center left point of the rectangle
        /// i.e. the left hand edge, centered vertically.
        /// </summary>
        /// <param name="r"></param>
        /// <returns>Center left point of the rectangle</returns>
        public static Point CenterLeft(this Rectangle r)
        {
            return new Point(r.Left, (int)(r.Top + (r.Height / 2D)));
        }
        /// <summary>
        /// Returns the center bottom point of the rectangle
        /// i.e. the bottom edge, centered horizontally.
        /// </summary>
        /// <param name="r"></param>
        /// <returns>Center bottom point of the rectangle</returns>
        public static Point CenterBottom(this Rectangle r)
        {
            return new Point((int)(r.Left + (r.Width / 2D)), r.Bottom);
        }
        /// <summary>
        /// Returns the center top point of the rectangle
        /// i.e. the topedge, centered horizontally.
        /// </summary>
        /// <param name="r"></param>
        /// <returns>Center top point of the rectangle</returns>
        public static Point CenterTop(this Rectangle r)
        {
            return new Point((int)(r.Left + (r.Width / 2D)), r.Top);
        }

        /// <summary>
        /// Evaluate if a point is on a semi-plane between two other points
        /// </summary>
        /// <param name="targetPoint"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static bool IsBetweenTwoPoints(this Point targetPoint, Point point1, Point point2)
        {
            double minX = System.Math.Min(point1.X, point2.X);
            double minY = System.Math.Min(point1.Y, point2.Y);
            double maxX = System.Math.Max(point1.X, point2.X);
            double maxY = System.Math.Max(point1.Y, point2.Y);

            double targetX = targetPoint.X;
            double targetY = targetPoint.Y;

            return minX.LessThanOrClose(targetX)
                  && targetX.LessThanOrClose(maxX)
                  && minY.LessThanOrClose(targetY)
                  && targetY.LessThanOrClose(maxY);
        }
    }
}
