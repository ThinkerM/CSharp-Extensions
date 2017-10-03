using NUnit.Framework;
using ThinkerExtensions.GeometryExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ThinkerExtensions.GeometryExtensions.Tests
{
    [TestFixture]
    public class GeometryExtensionsTests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 57)]
        [TestCase(-1, -57)]
        [TestCase(Math.PI, 180)]
        public void RadiansToDegreesTest(double radians, int expectedResult)
        {
            Assert.AreEqual(radians.ToDegrees(), expectedResult);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(90, 1.57)]
        public void DegreesToRadiansTest(int degrees, double expectedResult)
        {
            Assert.AreEqual(Math.Round(degrees.ToRadians(), 2), expectedResult);
        }

        [Test]
        public void DistanceToTest()
        {
            Point p1;
            Point p2;

            p1 = new Point(0,0);
            p2 = new Point(0,0);
            Assert.AreEqual(0, p1.DistanceTo(p2));

            p1 = new Point(10, 20);
            p2 = new Point(10, -50);
            Assert.AreEqual(70, p1.DistanceTo(p2));

            p1 = new Point(1,1);
            p2 = new Point(2,2);
            var roundedDistance = Math.Round(p1.DistanceTo(p2));
            Assert.AreEqual(1, roundedDistance);
        }
    }
}