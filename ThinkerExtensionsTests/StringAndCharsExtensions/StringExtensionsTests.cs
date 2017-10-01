using NUnit.Framework;
using ThinkerExtensions.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkerExtensions.StringAndCharsExtensions;

namespace ThinkerExtensions.StringExtensions.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        [TestCase("full", false)]
        [TestCase("", true)]
        [TestCase(null, true)]
        [TestCase("null", false)]
        public void IsNullOrEmptyTest(string input, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, input.IsNullOrEmpty());
        }

        [Test]
        [TestCase("string","String")]
        [TestCase("String", "String")]
        [TestCase("STRING", "STRING")]
        [TestCase("!", "!")]
        [TestCase("+plus", "+plus")]
        public void CapitalizeTest(string input, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.Capitalize());
        }

        [Test]
        public void WordifyTest()
        {
            Assert.Fail();
        }

        [Test]
        public void ParseEnumTest()
        {
            Assert.Fail();
        }

        [Test]
        public void ParseEnumTest1()
        {
            Assert.Fail();
        }

        [Test]
        public void RemoveLastCharacterTest()
        {
            Assert.Fail();
        }

        [Test]
        public void RemoveLastTest()
        {
            Assert.Fail();
        }

        [Test]
        public void RemoveFirstCharacterTest()
        {
            Assert.Fail();
        }

        [Test]
        public void RemoveFirstTest()
        {
            Assert.Fail();
        }
    }
}