using System.Collections.Generic;

namespace Brands.StudioSol.TechLeadTest.Tests.TestData
{
    public static class PrimeNumberAlgorithmTestData
    {
        private static readonly IEnumerable<int> IdentifyPrimeNumbersData = new[]
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 223, 277, 281, 383, 431, 479, 509, 563, 571
        };

        private static readonly IEnumerable<int> IdentifyNonPrimeNumbersData = new[]
        {
            1, 4, 6, 8, 9, 10, 12, 14, 15, 36, 64, 128, 130, 190, 200, 215, 264, 266, 320, 344, 351, 382, 480, 500, 502, 507, 510, 535, 532, 538, 540, 550, 10000
        };

        public static IEnumerable<object[]> IdentifyPrimeNumbers()
        {
            foreach (var primeNumber in IdentifyPrimeNumbersData)
            {
                yield return new object[] { primeNumber };
            }
        }

        public static IEnumerable<object[]> IdentifyNonPrimeNumbers()
        {
            foreach (var nonPrimeNumber in IdentifyNonPrimeNumbersData)
            {
                yield return new object[] { nonPrimeNumber };
            }
        }
    }
}
