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
            ("BATATAI",
            new RomanNumber
            {
                Number = "I",
                Value = 1
            }),
            ("PARALELEPIPEDO",
            new RomanNumber
            {
                Number = "I",
                Value = 1
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
