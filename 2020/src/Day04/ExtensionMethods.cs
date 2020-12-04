using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2020.Day04
{
    public static class ExtensionMethods
    {
        public static int CountValidPassports(this IList<string> input)
        {
            var completeInput = string.Join('\n', input);
            var dataPerPassport = completeInput.Split("\n\n");

            return dataPerPassport.Select(data => data.IsValidPassportData()).Count(valid => valid);
        }

        private static bool IsValidPassportData(this string input)
        {
            input = input.Replace('\n', ' ');
            var data = input.Split(' ');

            if (data.Length < 7)
            {
                return false;
            }

            if (data.Length == 8)
            {
                return true;
            }

            return data.Count(item => item.StartsWith("cid:")) == 0;
        }
    }
}