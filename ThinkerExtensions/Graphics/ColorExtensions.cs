using System.Drawing;

namespace ThinkerExtensions.Graphics
{
    /// <summary>
    /// Provides extensions methods for <see cref="System.Drawing.Color"/>
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Mean ARGB values of both colors
        /// </summary>
        /// <param name="color">First color to mix</param>
        /// <param name="other">Second color to mix with</param>
        /// <returns>ARGB average color</returns>
        public static Color MixWith(this Color color, Color other)
        {
            byte Mean(byte value1, byte value2) => (byte)((value1 + value2) / 2);

            byte a = System.Math.Min(Mean(color.A, other.A), (byte)255);
            byte r = System.Math.Min(Mean(color.R, other.R), (byte)255);
            byte g = System.Math.Min(Mean(color.G, other.G), (byte)255);
            byte b = System.Math.Min(Mean(color.B, other.B), (byte)255);
            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Get color which represents the inverted RGB values
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color Invert(this Color color)
        {
            Color invertedColor = Color.FromArgb(color.ToArgb() ^ 0xffffff);

            if (invertedColor.R > 110 && invertedColor.R < 150 &&
                invertedColor.G > 110 && invertedColor.G < 150 &&
                invertedColor.B > 110 && invertedColor.B < 150)
            {
                int avg = (invertedColor.R + invertedColor.G + invertedColor.B) / 3;
                avg = avg > 128 ? 200 : 60;
                invertedColor = Color.FromArgb(avg, avg, avg);
            }
            return invertedColor;
        }
    }
}
