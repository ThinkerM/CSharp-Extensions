using NUnit.Framework;
using ThinkerExtensions.StringAndCharsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkerExtensions.StringAndCharsExtensions.Tests
{
    [TestFixture]
    public class CharExtensionsTests
    {
        [Test]
        [TestCase('a', 'A')]
        [TestCase('!', '!')]
        [TestCase('7', '7')]
        [TestCase('Y', 'Y')]
        [TestCase('á', 'Á')]
        public void ToUpperTest(char input, char expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ToUpper());
        }

        [Test]
        [TestCase('B', 'b')]
        [TestCase('?', '?')]
        [TestCase('9', '9')]
        [TestCase('w', 'w')]
        [TestCase('Ž', 'ž')]
        public void ToLowerTest(char input, char expectedResult)
        {
            Assert.AreEqual(expectedResult, input.ToLower());
        }
    }
}