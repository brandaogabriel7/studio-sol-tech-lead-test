using Brands.StudioSol.TechLeadTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace Brands.StudioSol.TechLeadTest.Services
{
    public static class RomanNumbersFactory
    {
        private static readonly IDictionary<char, int> _mapping = new Dictionary<char, int>
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };

        /// <summary>
        /// Creates a <see cref="RomanNumber"/> from a string that contains a roman number.
        /// </summary>
        public static RomanNumber Create(string number)
        {
            var decomposedNumbers = GetDecomposedNumbers(number);

            var value = default(int);
            var previous = default(int);
            for (var index = decomposedNumbers.Length - 1; index >= default(int); index--)
            {
                if (previous > decomposedNumbers[index])
                {
                    value -= decomposedNumbers[index];
                }
                else
                {
                    value += decomposedNumbers[index];
                }
                previous = decomposedNumbers[index];
            }

            return new RomanNumber
            {
                Number = number,
                Value = value
            };
        }

        /// <summary>
        /// Replaces the roman digits for their numeric values.
        /// </summary>
        /// <param name="number">The roman number to decompose.</param>
        /// <returns>A collection with the numeric values for each digit of the roman number.</returns>
        private static int[] GetDecomposedNumbers(string number)
        {
            return number.Select(c => _mapping[c]).ToArray();
        }
    }
}
