using Brands.StudioSol.TechLeadTest.Models;

namespace Brands.StudioSol.TechLeadTest.Services.Interfaces
{
    public interface IRomanNumbersService
    {
        /// <summary>
        /// Given the <paramref name="searchText"/>, extract roman numbers, and identify which one is the lowest prime number.
        /// </summary>
        /// <param name="searchText">The search text to extract the numbers from.</param>
        /// <returns>The lowest prime number identified.</returns>
        RomanNumber GetLowestPrimeRomanNumber(string searchText);
    }
}
