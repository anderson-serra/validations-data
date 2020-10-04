using FluentAssertions;
using NUnit.Framework;

namespace Validations.Data.Tests
{
    [TestFixture]
    public class CNPJTests
    {
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        public void IsCNPJValid_MustReturnFalseWhenWnteringAnEmptyOrNullString(string cnpj, bool expected)
        {
            var sut = cnpj.IsCNPJValid();
            sut.Should().Be(expected);
        }

        [TestCase("0.000.000/0000-00", false)]
        [TestCase("000.000.000/0000-00", false)]
        [TestCase("0000000000000", false)]
        [TestCase("000000000000000", false)]
        public void IsCNPJValid_MustEnsureThatTheSizeIsNotDifferentFromFourteen(string cnpj, bool expected)
        {
            var sut = cnpj.IsCNPJValid();
            sut.Should().Be(expected);
        }

        [TestCase("00.000.000/0000-00", false)]
        [TestCase("11.111.111/1111-11", false)]
        [TestCase("22.222.222/2222-22", false)]
        [TestCase("33.333.333/3333-33", false)]
        [TestCase("44.444.444/4444-44", false)]
        [TestCase("55.555.555/5555-55", false)]
        [TestCase("66.666.666/6666-66", false)]
        [TestCase("77.777.777/7777-77", false)]
        [TestCase("88.888.888/8888-88", false)]
        [TestCase("99.999.999/9999-99", false)]
        public void IsCNPJValid_MustReturnFalseWhenItIsCnpjWithRepeatedNumbers(string cnpj, bool expected)
        {
            var sut = cnpj.IsCNPJValid();
            sut.Should().Be(expected);
        }

        [TestCase("28.12A.900/0001-91", false)]
        [TestCase("aa.aaa.aaa/aaaa-bb", false)]
        [TestCase("2c.120.900/0001-ab", false)]
        [TestCase("aaaaaa", false)]
        public void IsCNPJValid_MustEnsureThatOnlyStringsThatCanBeConvertedToNumbersCanProceed(string cnpj, bool expected)
        {
            var sut = cnpj.IsCNPJValid();
            sut.Should().Be(expected);
        }

        [TestCase("11.222.333/0001-81", true)]
        [TestCase("88.263.783/0001-47", true)]
        [TestCase("95.845.695/0002-23", false)]
        [TestCase("12.655.864/0001-51", false)]
        [TestCase("12655864000151", false)]
        [TestCase("88263783000147", true)]
        public void IsCNPJValid_MustValidateCNPJReturningTrueOrFalse(string cnpj, bool expected)
        {
            var sut = cnpj.IsCNPJValid();
            sut.Should().Be(expected);
        }

        [TestCase("", "")]
        [TestCase(" ", "")]
        [TestCase(null, "")]
        public void FormatCNPJ_EmptyStringMustBeReturnedWhenTheValueIsNullBlankOrEmpty(string cnpj, string expected)
        {
            var sut = cnpj.FormatCNPJ();
            sut.Should().Be(expected);
        }

        [TestCase("11.222.333/0001-81", "11.222.333/0001-81")]
        [TestCase("112223330001", "112223330001")]
        [TestCase("1178222333000181", "1178222333000181")]
        public void FormatCNPJ_IfTheSizeOfTheEnteredValueIsDifferentFromFourteenReturnTheValueItself(string cnpj, string expected)
        {
            var sut = cnpj.FormatCNPJ();
            sut.Should().Be(expected);
        }

        [TestCase("11222333000181", "11.222.333/0001-81")]
        [TestCase("88263783000147", "88.263.783/0001-47")]
        public void FormatCNPJ_MustCorrectlyFormatACNPJContainingFourteenCharacters(string cnpj, string expected)
        {
            var sut = cnpj.FormatCNPJ();
            sut.Should().Be(expected);
        }
    }
}