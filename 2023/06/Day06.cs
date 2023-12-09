using Basje.AdventOfCode.Y2023.Input;

using System.Text;
using System.Text.RegularExpressions;

namespace Basje.AdventOfCode.Y2023.D06
{
    public class Day06 : Solution<List<List<int>>>
    {
        protected override List<List<int>> ParseInput(string input)
        {
            return input
                .PerLine()
                .IgnoreEmptyLines()
                .Select(line => Regex.Matches(line, @"\d+"))
                .Select(line => line.Select(match => match.Value).Select(int.Parse).ToList())
                .ToList();
        }

        protected override object SolvePart1(List<List<int>> sheet)
        {
            const int TIME = 0;
            const int DISTANCE = 1;

            var answer = 1;

            for (var raceNumber = 0; raceNumber < sheet[TIME].Count; raceNumber++)
            {
                var numberOfWins = 0;
                var time = sheet[TIME][raceNumber];
                var distance = sheet[DISTANCE][raceNumber];
                for (var hold = 1; hold < time; hold++)
                {
                    if (hold * (time - hold) > distance)
                    {
                        numberOfWins++;
                    }
                }
                answer *= numberOfWins;
            }

            return answer;
        }

        protected override object SolvePart2(List<List<int>> sheet)
        {
            var timeBuilder = new StringBuilder();
            var distanceBuilder = new StringBuilder();

            foreach (var t in sheet[0])
            {
                timeBuilder.Append(t);
            }

            foreach (var d in sheet[1])
            {
                distanceBuilder.Append(d);
            }

            var time = long.Parse(timeBuilder.ToString());
            var distance = long.Parse(distanceBuilder.ToString());

            var numberOfWins = 0;
            for (var hold = 1; hold < time; hold++)
            {
                if (hold * (time - hold) > distance)
                {
                    numberOfWins++;
                }
            }
            return numberOfWins;
        }
    }
}
