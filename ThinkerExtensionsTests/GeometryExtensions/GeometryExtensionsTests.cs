using NUnit.Framework;
using System.Drawing;
using ThinkerExtensions.Geometry;

namespace ThinkerExtensions.GeometryExtensions.Tests
{
    [TestFixture]
    public class GeometryExtensionsTests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 57)]
        [TestCase(-1, -57)]
        [TestCase(System.Math.PI, 180)]
        public void RadiansToDegreesTest(double radians, int expectedResult)
        {
            Assert.AreEqual(radians.ToDegrees(), expectedResult);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(90, 1.57)]
        public void DegreesToRadiansTest(int degrees, double expectedResult)
        {
            Assert.AreEqual(System.Math.Round(degrees.ToRadians(), 2), expectedResult);
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
            var roundedDistance = System.Math.Round(p1.DistanceTo(p2));
            Assert.AreEqual(1, roundedDistance);
        }
    }
}