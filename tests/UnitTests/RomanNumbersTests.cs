using ConsoleUI;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class RomanNumbersTests
    {
        private RomanNumbers _romanNumbers;

        [SetUp]
        public void SetUp()
        {
            _romanNumbers = new RomanNumbers();
        }

        [TestCase("MMXXII", 2022)]
        [TestCase("MMMCMXCIX", 3999)]
        [TestCase("CMLXXXVIII", 988)]
        [TestCase("MDCXLI", 1641)]
        [TestCase("CDLXIV", 464)]
        [TestCase("CIX", 109)]
        [TestCase("MMXVII", 2017)]
        [TestCase("MCCXCVIII", 1298)]
        [TestCase("DCCLXXXVI", 786)]
        [TestCase("MD", 1500)]
        [TestCase("XCVIII", 98)]
        [TestCase("IV", 4)]
        [TestCase("DC", 600)]
        [TestCase("DV", 505)]
        [TestCase("DI", 501)]
        [TestCase("CXLV", 145)]
        [TestCase("MCCXXXVIII", 1238)]
        [TestCase("XXIX", 29)]
        [TestCase("XIX", 19)]
        [TestCase("XLV", 45)]
        [TestCase("XIV", 14)]
        [TestCase("CLIX", 159)]
        [TestCase("XVI", 16)]
        [TestCase("CCC", 300)]
        [TestCase("V", 5)]
        [TestCase("LVIII", 58)]
        [TestCase("XL", 40)]
        [TestCase("XXI", 21)]
        public void ShouldReturnExpectedIntegerNumber(string romanNumber, int integerNumber)
        {
            int result = _romanNumbers.ConvertRomanToInteger(romanNumber);

            Assert.AreEqual(integerNumber, result, $"{integerNumber} is not the same as {romanNumber}.");
        }

        [TestCase("IC")]
        [TestCase("DM")]
        [TestCase("XXM")]
        [TestCase("IIC")]
        [TestCase("XM")]
        [TestCase("XD")]
        [TestCase("IM")]
        [TestCase("ID")]
        [TestCase("VL")]
        [TestCase("CCIVDLM")]
        [TestCase("MMVX")]
        [TestCase("XIIIII")]
        [TestCase("IM A ROMAN NUMBER")]
        [TestCase("XIH")]
        [TestCase("ABC")]
        [TestCase("VX")]
        [TestCase("VV")]
        [TestCase("IIII")]
        public void ShouldReturnInvalidRomanNumber(string romanNumber)
        {
            int result = _romanNumbers.ConvertRomanToInteger(romanNumber);

            Assert.IsFalse(result > 0, $"{romanNumber} is actually a valid roman number.");
        }
    }
}