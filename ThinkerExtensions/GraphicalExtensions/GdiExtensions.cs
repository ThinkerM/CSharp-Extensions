using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ThinkerExtensions.GraphicalExtensions
{
    /// <summary>
    /// Provides helper methods related to Windows GDI
    /// </summary>
    public static class GdiExtensions
    {
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap Resize(this Image image, int width, int height)
        {
            if (image == null) { return null; }

            var destRect = new Rectangle(0, 0, width, height);
            var resultImage = new Bitmap(width, height);

            resultImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = System.Drawing.Graphics.FromImage(resultImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return resultImage;
        }
    }
}