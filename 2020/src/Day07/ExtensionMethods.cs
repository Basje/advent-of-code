using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode_2020.Day07
{
    public static class ExtensionMethods
    {
        public static Dictionary<int, IDictionary<int, int>> DetermineBagContentsWith(this IList<string> input, IDictionary<string, int> translationTable)
        {
            var possibleContentsPerBagType = new Dictionary<int, IDictionary<int, int>>();

            input
                .ToList()
                .ForEach(rule => possibleContentsPerBagType.Add(possibleContentsPerBagType.Count, rule.GetBagContentsWith(translationTable)));

            return possibleContentsPerBagType;
        }

        public static Dictionary<string, int> DetermineBagTypes(this IList<string> input)
        {
            var bagTypes = new Dictionary<string, int>();

            input
                .ToList()
                .ForEach(rule => bagTypes.Add(rule.GetSubjectBagType(), bagTypes.Count));

            return bagTypes;
        }

        public static IDictionary<int, int> GetBagContentsWith(this string rule, IDictionary<string, int> translationTable)
        {
            var possibleContents = new Dictionary<int, int>();

            var contents = rule
                .Split("contain ")
                .Last()
                .Replace(".", "")
                .Replace(" bags", "")
                .Replace(" bag", "")
                .Split(", ")
                .ToList();

            foreach (var content in contents)
            {
                var matches = Regex.Match(content, @"^(\d+) (.+)$");

                if (matches.Success)
                {
                    var count = int.Parse(matches.Groups[1].Value);
                    var bagType = matches.Groups[2].Value;
                    possibleContents.Add(translationTable[bagType], count);
                }
            }

            return possibleContents;
        }

        public static string GetSubjectBagType(this string rule)
        {
            return Regex
                .Match(rule, @"^([\w\s]+) bags contain")
                .Groups[1]
                .Value;
        }
    }
}