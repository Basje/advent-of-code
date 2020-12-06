using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode_2020.Day02
{
    [Command("day-2", Description = "Password Philosophy")]
    public class Solution : Puzzle
    {
        public Solution(CommandLineApplication app) : base(app)
        {
        }

        protected override Task<int> Solve()
        {
            var inputProvider = new InputProvider<string>(2, 1);
            var inputs = inputProvider.GetInputs();
            var regex = new Regex(@"^(\d+)-(\d+) (\w): (\w+)$");
            var correctSledRentalPlacePasswordCount = 0;
            var correctTobogganCasPasswordCount = 0;

            foreach (var input in inputs)
            {
                var matches = regex.Match(input);

                if (!matches.Success)
                {
                    continue;
                }

                var minumum = (int)Convert.ChangeType(matches.Groups[1].Value, typeof(int));
                var maximum = (int)Convert.ChangeType(matches.Groups[2].Value, typeof(int));
                var character = matches.Groups[3].Value;
                var password = matches.Groups[4].Value;
                var occurences = Regex.Matches(password, character).Count;

                if (minumum <= occurences && occurences <= maximum)
                {
                    correctSledRentalPlacePasswordCount++;
                }

                var positionalOccurences = 0;

                if (password[minumum - 1].ToString() == character)
                {
                    positionalOccurences++;
                }

                if (password[maximum - 1].ToString() == character)
                {
                    positionalOccurences++;
                }

                if (positionalOccurences == 1)
                {
                    correctTobogganCasPasswordCount++;
                }
            }

            Console.WriteLine($"Day 02 part 1: {correctSledRentalPlacePasswordCount}");
            Console.WriteLine($"Day 02 part 2: {correctTobogganCasPasswordCount}");

            return Task.FromResult(0);
        }
    }
}