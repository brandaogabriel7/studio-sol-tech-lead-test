using Brands.StudioSol.TechLeadTest.Models;
using Brands.StudioSol.TechLeadTest.Services.Interfaces;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brands.StudioSol.TechLeadTest.Services
{
    public class RomanNumbersService : IRomanNumbersService
    {
        private const char SPACE = ' ';

        private readonly IPrimeNumberAlgorithm _primeNumberAlgorithm;

        public RomanNumbersService(IPrimeNumberAlgorithm primeNumberAlgorithm)
        {
            _primeNumberAlgorithm = primeNumberAlgorithm;
        }

        /// <inheritdoc/>
        public RomanNumber GetLowestPrimeRomanNumber(string searchText)
        {
            var numbersInRoman = Regex.Replace(searchText, @"[^IVXLCDM\s]", SPACE.ToString()).Trim().Split(SPACE);
            return numbersInRoman.Select(n => RomanNumbersFactory.Create(n))
                .Where(rn => _primeNumberAlgorithm.IsPrimeNumber(rn.Value))
                .Aggregate((lowest, next) => next.Value < lowest.Value ? next : lowest);
        }
    }
}
