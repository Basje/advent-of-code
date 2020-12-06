using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2020.Day06
{
    public static class ExtensionMethods
    {
        public static IEnumerable<char> alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static IList<int> CountUnanimousAnswerPerGroup(this IList<string> input)
        {
            return input
                .Select(groupData => groupData.CountUnanimousAnswerPerGroup())
                .ToList();
        }

        public static int CountUnanimousAnswerPerGroup(this string input)
        {
            var unanimousAnswers = alphabet;
            var dataPerPerson = input.Split(' ');

            foreach (var personData in dataPerPerson)
            {
                unanimousAnswers = unanimousAnswers.Intersect(personData);
            }

            return unanimousAnswers.Count();
        }

        public static IList<int> CountUniqueAnswersPerGroup(this IList<string> input)
        {
            return input
                .Select(dataPerGroup => dataPerGroup
                    .Replace(" ", "")
                    .Distinct()
                    .Count())
                .ToList();
        }

        public static IList<string> ToAnswerDataPerGroup(this IList<string> input)
        {
            return string
                .Join('\n', input)
                .Split("\n\n")
                .Select(line => line.Replace('\n', ' '))
                .ToList();
        }
    }
}