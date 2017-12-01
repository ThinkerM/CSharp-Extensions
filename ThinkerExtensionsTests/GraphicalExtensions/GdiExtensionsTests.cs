using NUnit.Framework;
using System.Drawing;
using ThinkerExtensions.Graphics;

namespace ThinkerExtensions.GraphicalExtensions.Tests
{
    [TestFixture]
    public class GdiExtensionsTests
    {
        [Test]
        public void ResizeTest()
        {
            var image = new Bitmap(100,100);
            var resized = image.Resize(150, 200);
            Assert.AreEqual(resized.Width, 150);
            Assert.AreEqual(resized.Height, 200);
        }
    }
}