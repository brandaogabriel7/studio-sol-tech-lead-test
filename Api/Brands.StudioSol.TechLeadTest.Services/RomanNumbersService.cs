using Brands.StudioSol.TechLeadTest.Models;
using Brands.StudioSol.TechLeadTest.Services.Interfaces;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brands.StudioSol.TechLeadTest.Services
{
    public class RomanNumbersService : IRomanNumbersService
    {
        private const char SPACE = ' ';

        public RomanNumber GetLowestPrimeRomanNumber(string searchText)
        {
            var numbersInRoman = Regex.Replace(searchText, @"[^IVXLCDM\s]", SPACE.ToString()).Trim().Split(SPACE);
            return numbersInRoman.Select(n => RomanNumbersFactory.Create(n))
                .Aggregate((lowest, next) => next.Value < lowest.Value ? next : lowest);
        }
    }
}
