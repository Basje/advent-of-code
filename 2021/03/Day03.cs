namespace Basje.AdventOfCode.Y2021.D03
{
    public class Day03 : ISolution
    {
        private readonly List<string> diagnostics;

        public Day03(IEnumerable<string> input)
        {
            diagnostics = input.ToList();
        }

        public string SolvePart1()
        {
            var lineLength = diagnostics[0].Length;
            var counts = new int[lineLength];
            var lineCount = diagnostics.Count;

            diagnostics.ForEach(diagnostic => {
                for (var i = 0; i < diagnostic.Length; i++)
                {
                    counts[i] += int.Parse(diagnostic.Substring(i, 1));
                }
            });

            var gammaRate = 0;
            var epsilonRate = 0;
            var maxInt = (int)Math.Pow(2, lineLength) - 1;

            for (var i = 0; i < counts.Length; i++)
            {
                gammaRate += ((2 * counts[i] > lineCount) ? 1 : 0) << lineLength - i - 1;
                epsilonRate += ((2 * counts[i] < lineCount) ? 1 : 0) << lineLength - i - 1;

            }

            var answer = checked(gammaRate * epsilonRate);

            return answer.ToString();
        }

        public string SolvePart2()
        {
            var lineLength = diagnostics[0].Length;

            var oxygenGeneratorRatingValues = diagnostics.ToList();
            var CO2ScrubberRatingValues = diagnostics.ToList();

            var oxygenPosition = 0;
            var CO2Position = 0;

            while (oxygenPosition < lineLength && oxygenGeneratorRatingValues.Count > 1)
            {
                var bitCount = 0;

                oxygenGeneratorRatingValues.ForEach(oxygenGenRate => {
                    bitCount += int.Parse(oxygenGenRate.Substring(oxygenPosition, 1));
                });

                var mostCommon = bitCount * 2 >= oxygenGeneratorRatingValues.Count ? '1' : '0';

                oxygenGeneratorRatingValues = oxygenGeneratorRatingValues.Where(oxygenGenRate => oxygenGenRate[oxygenPosition] == mostCommon).ToList();

                oxygenPosition++;
            }

            while (CO2Position < lineLength && CO2ScrubberRatingValues.Count > 1)
            {
                var bitCount = 0;

                CO2ScrubberRatingValues.ForEach(CO2GenRate => {
                    bitCount += int.Parse(CO2GenRate.Substring(CO2Position, 1));
                });

                var leastCommon = bitCount * 2 >= CO2ScrubberRatingValues.Count ? '0' : '1';

                CO2ScrubberRatingValues = CO2ScrubberRatingValues.Where(CO2GenRate => CO2GenRate[CO2Position] == leastCommon).ToList();

                CO2Position++;
            }

            var oxygenNumber = Convert.ToInt32(oxygenGeneratorRatingValues.Single(), 2);
            var CO2Number = Convert.ToInt32(CO2ScrubberRatingValues.Single(), 2);

            var answer = checked(oxygenNumber * CO2Number);

            return answer.ToString();
        }
    }
}
