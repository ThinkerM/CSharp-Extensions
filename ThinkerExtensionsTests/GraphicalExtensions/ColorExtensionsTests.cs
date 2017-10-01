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
    public class ColorExtensionsTests
    {
        [Test]
        public void MixWithTest()
        {
            Color c1;
            Color c2;

            c1 = Color.Black;
            c2 = c1;
            Assert.AreEqual(Color.Black.ToArgb(), c1.MixWith(c2).ToArgb());

            c1 = Color.FromArgb(10, 10, 10, 10);
            c2 = Color.FromArgb(12, 12, 12, 12);
            var expectedMixColor = Color.FromArgb(11, 11, 11, 11);
            Assert.AreEqual(expectedMixColor.ToArgb(), c1.MixWith(c2).ToArgb());
        }

        [Test]
        public void InvertTest()
        {
            Assert.AreEqual(Color.Black.ToArgb(), Color.White.Invert().ToArgb());
            Assert.AreEqual(Color.Blue.Invert().ToArgb(), Color.Yellow.ToArgb());
        }
    }
}