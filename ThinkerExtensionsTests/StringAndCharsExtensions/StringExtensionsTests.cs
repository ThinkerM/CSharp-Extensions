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
        [TestCase("ALLUPPER", "ALLUPPER")]
        [TestCase("camelCaseWord", "camel Case Word")]
        [TestCase("PascalCaseWord", "Pascal Case Word")]
        [TestCase("WordWithNumber42", "Word With Number42")]
        [TestCase("42leadingNumber", "42leading Number")]
        public void WordifyTest(string input, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.Wordify());
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
        [TestCase("STRING", "STRIN")]
        [TestCase("1", "")]
        [TestCase("SpaceAtTheEnd ", "SpaceAtTheEnd")]
        [TestCase("", "")]
        public void RemoveLastCharacterTest(string input, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.RemoveLastCharacter());
        }

        [Test]
        [TestCase("ABC", 0, "ABC")]
        [TestCase("ABC", 1, "AB")]
        [TestCase("ABC", 2, "A")]
        [TestCase("ABC", 3, "")]
        [TestCase("ABC", 10, "")]
        [TestCase("", 2, "")]
        [TestCase("", 0, "")]
        public void RemoveLastTest(string input, int amountToRemove, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.RemoveLast(amountToRemove));
        }

        [Test]
        [TestCase("ABC","BC")]
        [TestCase("1", "")]
        [TestCase("", "")]
        public void RemoveFirstCharacterTest(string input, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.RemoveFirstCharacter());
        }

        [Test]
        [TestCase("ABC", 0, "ABC")]
        [TestCase("ABC", 1, "BC")]
        [TestCase("ABC", 2, "C")]
        [TestCase("ABC", 3, "")]
        [TestCase("ABC", 10, "")]
        [TestCase("", 2, "")]
        [TestCase("", 0, "")]
        public void RemoveFirstTest(string input, int amountToRemove, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.RemoveFirst(amountToRemove));
        }
    }
}