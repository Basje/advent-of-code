using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_2019
{
    internal static class InputProvider
    {
        internal static IEnumerable<int> GetIntegers(string relativePath)
        {
            return GetStrings(relativePath)
                .Select(input => int.Parse(input));
        }

        internal static IEnumerable<string> GetStrings(string relativePath)
        {
            return ReadLines(BuildFullPath(relativePath));
        }

        private static string BuildFullPath(string relativePath)
        {
            relativePath = NaiveFilter(relativePath);

            return @$"{Directory.GetCurrentDirectory()}\{relativePath}";
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
    }
}
