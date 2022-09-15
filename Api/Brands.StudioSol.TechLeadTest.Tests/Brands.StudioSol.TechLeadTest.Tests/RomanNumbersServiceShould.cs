using Brands.StudioSol.TechLeadTest.Models;
using Brands.StudioSol.TechLeadTest.Services;
using Brands.StudioSol.TechLeadTest.Services.Interfaces;
using Brands.StudioSol.TechLeadTest.Tests.TestData;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Brands.StudioSol.TechLeadTest.Tests
{
    public class RomanNumbersServiceShould
    {
        private readonly IPrimeNumberAlgorithm _primeNumberAlgorithm;
        private readonly RomanNumbersService _romanNumbersService;

        public RomanNumbersServiceShould()
        {
            _primeNumberAlgorithm = Substitute.For<IPrimeNumberAlgorithm>();
            _romanNumbersService = new RomanNumbersService(_primeNumberAlgorithm);
        }

        [Theory(DisplayName = "get the lowest roman number identified in the search text")]
        [MemberData(nameof(RomanNumbersServiceTestData.GetLowestRomanNumberTestData), MemberType = typeof(RomanNumbersServiceTestData))]
        public void GetLowestRomanNumberFromSearchText(
            string searchText, RomanNumber lowestRomanNumber)
        {
            _primeNumberAlgorithm.IsPrimeNumber(lowestRomanNumber.Value).Returns(true);

            var romanNumber = _romanNumbersService.GetLowestPrimeRomanNumber(searchText);

            romanNumber.Should().BeEquivalentTo(lowestRomanNumber);
        }
    }
}
