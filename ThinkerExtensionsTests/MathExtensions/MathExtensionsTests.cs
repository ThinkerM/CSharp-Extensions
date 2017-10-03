using ThinkerExtensions.MathExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ThinkerExtensions.MathExtensions.Tests
{
    [TestFixture]
    public class MathExtensionsTests
    {
        [Test]
        [TestCase(1, false)]
        [TestCase(null, false)]
        [TestCase(double.NaN, true)]
        [TestCase(double.NegativeInfinity, false)]
        public void IsNaNTest(object value, bool expectedResult)
        {
            try
            {
                if (value == null) return;

                double x = (double)value;
                Assert.AreEqual(x.IsNaN(), expectedResult);
            }
            catch (InvalidCastException)
            { Assert.IsFalse(expectedResult); }
            catch (Exception e)
            { Assert.Fail(e.Message); }
        }

        [Test]
        [TestCase(-1, 1, -1)]
        [TestCase(0, 100, 0)]
        [TestCase(2, 2, 4)]
        [TestCase(4, 0.5, 2)]
        [TestCase(10, 3, 1000)]
        [TestCase(-150, 0, 1)]
        [TestCase(-100, -1, -0.01)]
        [TestCase(1, 150, 1)]
        public void PowerTestInt(int value, double power, double expectedResult)
        {
            Assert.AreEqual(expectedResult, value.Power(power));
        }

        [Test]
        [TestCase(2.5, 2, 6.25)]
        [TestCase(0.1, 1, 0.1)]
        [TestCase(100, -1, 0.01)]
        public void PowerTestDouble(double value, double power, double expectedResult)
        {
            Assert.AreEqual(expectedResult, value.Power(power));
        }

        [Test]
        [TestCase(1.656, 0, 2)]
        [TestCase(1.656, 1, 1.7)]
        [TestCase(1.656, 2, 1.66)]
        [TestCase(1.656, 3, 1.656)]
        [TestCase(1.656, 4, 1.6560)]
        [TestCase(5.209014, 2, 5.21)]
        [TestCase(0.9, 0, 1)]
        public void RoundTest(double value, int decimalPlaces, double expectedResult)
        {
            Assert.AreEqual(expectedResult, value.Round(decimalPlaces));
        }

        [Test]
        [TestCase(10, 20, 15)]
        [TestCase(1, 1, 1)]
        [TestCase(-100, 100, 0)]
        [TestCase(10, 5, 7.5)]
        [TestCase(5, 10, 7.5)]
        public void MeanTestInt(int value1, int value2, double expectedResult)
        {
            Assert.AreEqual(expectedResult, value1.Mean(value2));
        }

        [Test]
        [TestCase(7.5, 8, 7.75)]
        [TestCase(2.25, 2.30, 2.275)]
        [TestCase(10.01, 9.99, 10)]
        public void MeanTestDouble(double value1, double value2, double expectedResult)
        {
            Assert.AreEqual(expectedResult, value1.Mean(value2));
        }

        [Test]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(1, false)]
        [TestCase(0, false)]
        [TestCase(-1, false)]
        [TestCase(17, true)]
        [TestCase(472882049, true)]
        [TestCase(472882047, false)]
        public void IsPrimeTestInt(int value, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, value.IsPrime());
        }

        [Test]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(1, false)]
        [TestCase(0, false)]
        [TestCase(-11, false)]
        [TestCase(17, true)]
        [TestCase(487, true)]
        [TestCase(184467440739551557, false)]
        [TestCase(184467440739551553, false)]
        [TestCase(92233720368575807, false)]
        public void IsPrimeTestLong(long value, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, value.IsPrime());
        }
    }
}