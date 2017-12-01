using NUnit.Framework;
using System;
using ThinkerExtensions.Text;

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

        public enum TestEnum { Enum1, Enum2, Enum3 }

        [Test]
        [TestCase("enum1", TestEnum.Enum1)]
        [TestCase("Enum1", TestEnum.Enum1)]
        [TestCase("EnUM1", TestEnum.Enum1)]
        [TestCase("enum2", TestEnum.Enum2)]
        [TestCase("enum3", TestEnum.Enum3)]
        [TestCase("black", ConsoleColor.Black)]
        [TestCase("A", ConsoleKey.A)]
        [TestCase("conTroLBrEAK", ConsoleSpecialKey.ControlBreak)]
        [TestCase("", TestEnum.Enum3)]
        public void ParseEnumTest<TEnum>(string input, TEnum expectedResult)
        {
            try
            {
                input.ParseEnum<TEnum>();
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(input.IsNullOrEmpty());
                return;
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.AreEqual(expectedResult, input.ParseEnum<TEnum>());
        }

        [Test]
        [TestCase("enum1", false, TestEnum.Enum1, true)]
        [TestCase("Enum1", false, TestEnum.Enum1, false)]
        [TestCase("EnUM1", true, TestEnum.Enum1, false)]
        [TestCase("black", true, ConsoleColor.Black, false)]
        [TestCase("A", true, ConsoleKey.A, false)]
        [TestCase("conTroLBrEAK", false, ConsoleSpecialKey.ControlBreak, true)]
        public void ParseEnumSpecifyIgnoreCaseTest<TEnum>(string input, bool ignoreCase, TEnum expectedResult, bool parsingShouldFail)
        {
            try
            {
                input.ParseEnum<TEnum>(ignoreCase);
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(parsingShouldFail);
                return;
            } 
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.IsFalse(parsingShouldFail);
            Assert.AreEqual(expectedResult, input.ParseEnum<TEnum>(ignoreCase));
        }

        [Test]
        [TestCase("FakeEnum", "FakeEnum")]
        [TestCase("FakeEnum", int.MaxValue)]
        [TestCase("Black", ConsoleColor.Black)]
        [TestCase("eNuM1", TestEnum.Enum1)]
        public void ParseEnumBadInputsTest<T>(string input, T expectedResult) 
            //not-enum target types expected to throw ArgumentException
        {
            bool targetTypeIsEnum = typeof(T).IsEnum;
            try
            {
                input.ParseEnum<T>();
            }
            catch (ArgumentException)
            {
                if (!targetTypeIsEnum)
                    return; //Exception was OK to throw
            }
            Assert.IsTrue(targetTypeIsEnum);
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

        [Test]
        [TestCase("12", typeof(int), true)]
        [TestCase("-1", typeof(int), true)]
        [TestCase("string", typeof(int), false)]
        [TestCase("12.5.2018", typeof(DateTime), true)]
        public void CanConvertToTest(string input, Type targetType, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, input.CanConvertTo(targetType));
        }

        [Test]
        [TestCase("0", 0)]
        [TestCase("2", 2)]
        [TestCase("-100", -100)]
        [TestCase("hundred", 0)]
        [TestCase("hundred", -5, -5)]
        [TestCase("150", 150, -1)]
        [TestCase("str28", 0)]
        public void ParseIntSafeTest(string input, int expectedValue, int defaultValue = 0)
        {
            Assert.AreEqual(expectedValue, input.ParseIntSafe(defaultValue));
        }
    }
}