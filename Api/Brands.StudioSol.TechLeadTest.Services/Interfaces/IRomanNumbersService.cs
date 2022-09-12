using Brands.StudioSol.TechLeadTest.Models;

namespace Brands.StudioSol.TechLeadTest.Services.Interfaces
{
    public interface IRomanNumbersService
    {
        RomanNumber GetLowestRomanNumber(string text);
    }
}
