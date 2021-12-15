namespace Basje.AdventOfCode.Y2021.D08
{
    public class Day08 : ISolution
    {
        private readonly List<string> signalPatterns;
        private readonly List<string[]> outputValues;

        private static readonly int[] uniqueLengths = new int[] { 2, 3, 4, 7 };

    public Day08(IEnumerable<string> input)
        {
            var splitInput = input.Select(line => line.Split(" | "));
            signalPatterns = splitInput.Select(line => line[0]).ToList();
            outputValues = splitInput.Select(line => line[1].Split(" ")).ToList();
        }

        public string SolvePart1()
        {
            var uniqueLengthSegments = outputValues.SelectMany(y => y.Where(HasUniqueNumberOfSegments));

            return uniqueLengthSegments.Count().ToString();
        }

        public string SolvePart2()
        {
            throw new NotImplementedException();
        }

        public static bool HasUniqueNumberOfSegments(string digit)
        {
            return uniqueLengths.Contains(digit.Length);
        }
    }
}
