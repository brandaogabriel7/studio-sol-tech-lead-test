using Brands.StudioSol.TechLeadTest.Services;
using Brands.StudioSol.TechLeadTest.Tests.TestData;
using FluentAssertions;
using Xunit;

namespace Brands.StudioSol.TechLeadTest.Tests
{
    public class TrialDivisionPrimeNumberAlgorithmShould
    {
        private readonly TrialDivisionPrimeNumberAlgorithm _primeNumberAlgorithm;

        public TrialDivisionPrimeNumberAlgorithmShould()
        {
            _primeNumberAlgorithm = new TrialDivisionPrimeNumberAlgorithm();
        }

        [Theory(DisplayName = "identify prime numbers")]
        [MemberData(nameof(PrimeNumberAlgorithmTestData.IdentifyPrimeNumbers), MemberType = typeof(PrimeNumberAlgorithmTestData))]
        public void IdentifyPrimeNumbers(int primeNumber)
        {
            var isPrimeNumber = _primeNumberAlgorithm.IsPrimeNumber(primeNumber);

            isPrimeNumber.Should().BeTrue();
        }

        [Theory(DisplayName = "identify non prime numbers")]
        [MemberData(nameof(PrimeNumberAlgorithmTestData.IdentifyNonPrimeNumbers), MemberType = typeof(PrimeNumberAlgorithmTestData))]
        public void IdentifyNonPrimeNumbers(int nonPrimeNumber)
        {
            var isPrimeNumber = _primeNumberAlgorithm.IsPrimeNumber(nonPrimeNumber);

            isPrimeNumber.Should().BeFalse();
        }
    }
}
