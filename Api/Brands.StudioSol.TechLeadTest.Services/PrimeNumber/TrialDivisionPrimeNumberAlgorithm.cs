using Brands.StudioSol.TechLeadTest.Services.Interfaces;

namespace Brands.StudioSol.TechLeadTest.Services.PrimeNumber
{
    public class TrialDivisionPrimeNumberAlgorithm : IPrimeNumberAlgorithm
    {
        /// <inheritdoc/>
        /// <remarks>
        /// This algorithm is called Trial Division and it is using the 6k+-1 rule to optimize the loop.
        /// </remarks>
        public bool IsPrimeNumber(int value)
        {
            if (value == 2 || value == 3)
            {
                return true;
            }

            if (value <= 1 || value % 2 == 0 || value % 3 == 0)
            {
                return default;
            }

            for (var divisor = 5; divisor * divisor <= value; divisor += 6)
            {
                if (value % divisor == 0)
                {
                    return default;
                }
            }
            return true;
        }
    }
}
