using System;

namespace GeometryExtensions
{
    /// <summary>
    /// Normalized representation of an angle (within 0-2π / 0-360°)
    /// </summary>
    public struct Angle : IEquatable<Angle>
    {
        /// <summary>
        /// Representation of angle in degrees
        /// </summary>
        public int Degrees { get; }

        /// <summary>
        /// Representation of angle in radians
        /// </summary>
        public double Radians 
            => GeometryExtensions.DegreesToRadians(Degrees);

        private Angle(int degrees)
        {
            this.Degrees = Normalize(degrees);
        }

        private Angle(double radians)
        {
            Degrees = Normalize(GeometryExtensions.RadiansToDegrees(radians));
        }

        /// <summary>
        /// Construct angle from a value in degrees
        /// </summary>
        /// <param name="degrees">Degrees representing angle</param>
        /// <returns>Angle represented by value</returns>
        public static Angle FromDegrees(int degrees)
        {
            return new Angle(Normalize(degrees));
        }

        /// <summary>
        /// Construct angle from a value in radians
        /// </summary>
        /// <param name="radians">Radians representing angle</param>
        /// <returns>Angle represented by value</returns>
        public static Angle FromRadians(double radians)
        {
            return new Angle(Normalize(GeometryExtensions.RadiansToDegrees(radians)));
        }

        /// <summary>
        /// Calculate angle mirrored against the vertical axis
        /// </summary>
        /// <param name="toFlip">Angle to mirror</param>
        /// <returns>Mirrored angle</returns>
        public static Angle FlipAgainstYAxis(Angle toFlip)
        {
            return new Angle(180 - toFlip.Degrees);
        }

        /// <summary>
        /// Adjust self to a mirrored angle in regards to the vertical axis
        /// </summary>
        public void FlipAgainstYAxis()
        {
            this = FromDegrees(180 - this.Degrees);
        }

        /// <summary>
        /// Determine equality of angle with another object
        /// </summary>
        /// <param name="other">Object to compare with</param>
        /// <returns>True for "Equal", False otherwise</returns>
        public override bool Equals(object other)
        {
            var otherAngle = other as Angle?;
            return Degrees == otherAngle?.Degrees;
        }

        /// <summary>
        /// Determine equality of angle with another angle
        /// </summary>
        /// <param name="other">Angle to compare with</param>
        /// <returns>True for "Equal", False otherwise</returns>
        public bool Equals(Angle other) 
            => this.Degrees == other.Degrees;

        /// <summary>
        /// Determine equality of two angles
        /// </summary>
        /// <param name="angle1"></param>
        /// <param name="angle2"></param>
        /// <returns>True if equal, False otherwise</returns>
        public static bool operator == (Angle angle1, Angle angle2)
        {
            return angle1.Equals(angle2);
        }

        /// <summary>
        /// Determine inequality of two angles
        /// </summary>
        /// <param name="angle1"></param>
        /// <param name="angle2"></param>
        /// <returns>True if not equal, false if equal</returns>
        public static bool operator != (Angle angle1, Angle angle2)
        {
            return !angle1.Equals(angle2);
        }

        /// <summary>
        /// Add up two angles
        /// </summary>
        /// <param name="angle1"></param>
        /// <param name="angle2"></param>
        /// <returns>Result of adding two angles</returns>
        public static Angle operator + (Angle angle1, Angle angle2)
        {
            return new Angle(angle1.Degrees + angle2.Degrees);
        }

        /// <summary>
        /// Add degrees to an angle
        /// </summary>
        /// <param name="angle">Angle to add to</param>
        /// <param name="degrees">Degrees to add</param>
        /// <returns>Result of addition of degrees to angle</returns>
        public static Angle operator + (Angle angle, int degrees)
        {
            return new Angle(angle.Degrees + degrees);
        }

        /// <summary>
        /// Subtract degrees from angle
        /// </summary>
        /// <param name="angle">Angle to subtract from</param>
        /// <param name="degrees">Degrees to subtract</param>
        /// <returns>Result of subtraction of degrees from angle</returns>
        public static Angle operator - (Angle angle, int degrees)
        {
            return new Angle(angle.Degrees - degrees);
        }

        /// <summary>
        /// Subtract two angles
        /// </summary>
        /// <param name="angle1"></param>
        /// <param name="angle2"></param>
        /// <returns>Result of subtracting two angles</returns>
        public static Angle operator - (Angle angle1, Angle angle2)
        {
            return new Angle(angle1.Degrees - angle2.Degrees);
        }

        /// <summary>
        /// Get hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return Degrees;
        }

        /// <summary>
        /// Ensure value is 0-360
        /// </summary>
        /// <param name="degrees">Value to normalize</param>
        private static int Normalize(int degrees)
        {
            degrees %= 360;
            if (degrees < 0)
            { degrees += 360; }
            return degrees;
        }
    }
}
