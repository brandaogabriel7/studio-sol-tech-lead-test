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
            ("IVONE",
            new RomanNumber
            {
                Number = "IV",
                Value = 4
            }),
            ("MEU",
            new RomanNumber
            {
                Number = "M",
                Value = 1000
            }),
            ("HAHAHAXLVIIOPAAAAA",
            new RomanNumber
            {
                Number = "XLVII",
                Value = 47
            }),
            ("DIIIAS",
            new RomanNumber
            {
                Number = "DIII",
                Value = 503
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
