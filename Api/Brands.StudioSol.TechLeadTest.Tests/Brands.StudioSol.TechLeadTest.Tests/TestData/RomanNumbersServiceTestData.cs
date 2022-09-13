using Brands.StudioSol.TechLeadTest.Models;
using System.Collections.Generic;

namespace Brands.StudioSol.TechLeadTest.Tests.TestData
{
    public static class RomanNumbersServiceTestData
    {
        public static readonly IEnumerable<(string searchText, RomanNumber lowestRomanNumber)> GetLowestRomanNumberData = new[]
        {
            ("AXIBIV",
            new RomanNumber
            {
                Number = "XI",
                Value = 11
            }),
            ("BATATAII",
            new RomanNumber
            {
                Number = "II",
                Value = 2
            }),
            ("PARALELEPIIIPEDO",
            new RomanNumber
            {
                Number = "III",
                Value = 3
            }),
            ("IVONEVII",
            new RomanNumber
            {
                Number = "VII",
                Value = 7
            }),
            ("MEUXIIIOO",
            new RomanNumber
            {
                Number = "XIII",
                Value = 13
            }),
            ("HAHAHAXLVIIOPAAAAA",
            new RomanNumber
            {
                Number = "XLVII",
                Value = 47
            })
        };

        public static IEnumerable<object[]> GetLowestRomanNumberTestData()
        {
            foreach (var (searchText, lowestRomanNumber) in GetLowestRomanNumberData)
            {
                yield return new object[] { searchText, lowestRomanNumber };
            }
        }
    }
}
