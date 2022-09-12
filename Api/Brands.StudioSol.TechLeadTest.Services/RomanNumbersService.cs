using Brands.StudioSol.TechLeadTest.Models;
using Brands.StudioSol.TechLeadTest.Services.Interfaces;

namespace Brands.StudioSol.TechLeadTest.Services
{
    public class RomanNumbersService : IRomanNumbersService
    {
        public RomanNumber GetLowestRomanNumber(string text)
        {
            return new RomanNumber { Number = text };
        }
    }
}
