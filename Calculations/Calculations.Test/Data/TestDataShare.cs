using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculations.Test
{
    public static class TestDataShare
    {
        public static IEnumerable<object[]> IsOddOrEvenData
        {
            get
            {
                yield return new object[] { 1, true };
                yield return new object[] { 200, false };

            }
        }

        public static IEnumerable<object[]> IsOddOrEvenDataFromExternalResource
        {
            get
            {
                var allLines = System.IO.File.ReadAllLines("Data\\IsOddOrEventTestData.txt");

                return allLines.Select(e =>
                 {
                     var lineSplit = e.Split(',');
                     return new object[] { Convert.ToInt32(lineSplit[0]), bool.Parse(lineSplit[1]) };
                 });
            }
        }
    }
}
