using NUnit.Framework;
using ThinkerExtensions.GraphicalExtensions;
using System;
using System.Collections.Generic;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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