using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_2019
{
    internal static class InputProvider
    {
        private const string DAY01_INPUT_LOCATION = @"Day-01\input.txt";
        private const string DAY02_INPUT_LOCATION = @"Day-02\input.txt";

        internal static List<int> Day1Input { get => GetLinesFrom(DAY01_INPUT_LOCATION).ToIntegers(); }
        internal static List<int> Day2Input { get => GetFirstLineFrom(DAY02_INPUT_LOCATION).Split(',').ToIntegers(); }

        private static string BuildFullPath(string relativePath)
        {
            relativePath = NaiveFilter(relativePath);

            return @$"{Directory.GetCurrentDirectory()}\{relativePath}";
        }

        private static string GetFirstLineFrom(string relativePath)
        {
            return GetLinesFrom(relativePath).First();
        }

        private static IEnumerable<string> GetLinesFrom(string relativePath)
        {
            return ReadLines(BuildFullPath(relativePath));
        }

        private static string NaiveFilter(string key)
        {
            return key.Trim('\\', ' ', '.', '/');
        }

        private static IEnumerable<string> ReadLines(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                return new List<string>();
            }

            return File.ReadAllLines(fullPath);
        }

        private static List<int> ToIntegers(this IEnumerable<string> input)
        {
            return input
                .Select(code => int.Parse(code))
                .ToList();
        }
    }
}
