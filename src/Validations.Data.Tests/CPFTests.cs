using FluentAssertions;
using NUnit.Framework;

namespace Validations.Data.Tests
{
    [TestFixture]
    public class CPFTests
    {
        [TestCase("597.027.530-15", true)]
        [TestCase("163.741.960-07", true)]
        [TestCase("784.658.333.01", false)]
        [TestCase("92837823058", true)]
        [TestCase("99185264788", false)]
        public void IsCPFValid_MustValidateCPFReturningTrueOrFalse(string cpf, bool expected)
        {
            var sut = cpf.IsCPFValid();
            sut.Should().Be(expected);
        }

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        public void IsCPFValid_EmptyStringMustBeReturnedWhenTheValueIsNullBlankOrEmpty(string cnpj, bool expected)
        {
            var sut = cnpj.IsCPFValid();
            sut.Should().Be(expected);
        }

        [TestCase("649.698.695-663", false)]
        [TestCase("649.68.695-66", false)]
        [TestCase("649698695663", false)]
        [TestCase("6496869566", false)]
        public void IsCPFValid_MustEnsureThatTheSizeIsNotDifferentFromEleven(string cnpj, bool expected)
        {
            var sut = cnpj.IsCPFValid();
            sut.Should().Be(expected);
        }

        [TestCase("597.a27.530-15", false)]
        [TestCase("aaa.02c.530-15", false)]
        public void IsCPFValid_MustEnsureThatOnlyStringsThatCanBeConvertedToNumbersCanProceed(string cnpj, bool expected)
        {
            var sut = cnpj.IsCPFValid();
            sut.Should().Be(expected);
        }

        [TestCase("000.000.000-00", false)]
        [TestCase("111.111.111-11", false)]
        [TestCase("222.222.222-22", false)]
        [TestCase("333.333.333-33", false)]
        [TestCase("444.444.444-44", false)]
        [TestCase("555.555.555-55", false)]
        [TestCase("666.666.666-66", false)]
        [TestCase("777.777.777-77", false)]
        [TestCase("888.888.888-88", false)]
        [TestCase("999.999.999-99", false)]
        public void IsCPFValid_MustReturnFalseWhenItIsCnpjWithRepeatedNumbers(string cpf, bool expected)
        {
            var sut = cpf.IsCPFValid();
            sut.Should().Be(expected);
        }
    }
}
