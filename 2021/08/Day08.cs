namespace Basje.AdventOfCode.Y2021.D08
{
    public class Day08 : ISolution
    {
        private readonly List<string[]> signalPatterns;
        private readonly List<string[]> outputValues;

        private static readonly int[] uniqueLengths = new int[] { 2, 3, 4, 7 };

    public Day08(IEnumerable<string> input)
        {
            var splitInput = input.Select(line => line.Split(" | "));

            signalPatterns = splitInput.Select(line => line[0].Split(" ")).ToList();
            outputValues = splitInput.Select(line => line[1].Split(" ")).ToList();
        }

        public string SolvePart1()
        {
            var uniqueLengthSegments = outputValues.SelectMany(y => y.Where(HasUniqueNumberOfSegments));

            return uniqueLengthSegments.Count().ToString();
        }

        public string SolvePart2()
        {
            var sum = 0;

            for (var i = 0; i < signalPatterns.Count; i++)
            {
                var mapping = MapSignalToDigits(signalPatterns[i]);
                var output = 0;

                foreach (var pattern in outputValues[i])
                {
                    output *= 10;

                    foreach (var entry in mapping)
                    {
                        if (pattern.Intersect(entry.Key).Count() == pattern.Length && entry.Key.Intersect(pattern).Count() == entry.Key.Length)
                        {
                            output += entry.Value;
                        }
                    }
                }
                sum += output;
            }

            return sum.ToString();
        }

        public static bool HasUniqueNumberOfSegments(string digit)
        {
            return uniqueLengths.Contains(digit.Length);
        }

        public static Dictionary<string, int> MapSignalToDigits(string[] signal)
        {
            var mapping = new Dictionary<string, int>();
            string four = string.Empty;
            string seven = string.Empty;

            // First get the ones we can identify independently
            foreach (var pattern in signal)
            {
                switch (pattern.Length)
                {
                    case 2:
                        mapping.Add(pattern, 1);
                        break;
                    case 3:
                        mapping.Add(pattern, 7);
                        seven = pattern;
                        break;
                    case 4:
                        mapping.Add(pattern, 4);
                        four = pattern;
                        break;
                    case 7:
                        mapping.Add(pattern, 8);
                        break;
                }
            }

            foreach (var pattern in signal)
            {
                var segmentsEqualToFour = four.Intersect(pattern).Count();
                var segmentsEqualToSeven = seven.Intersect(pattern).Count();

                switch (pattern.Length)
                {
                    // 2, 3 or 5
                    case 5:
                        if (segmentsEqualToFour == 2 && segmentsEqualToSeven == 2)
                        {
                            mapping.Add(pattern, 2);
                        }
                        if (segmentsEqualToFour == 3 && segmentsEqualToSeven == 3)
                        {
                            mapping.Add(pattern, 3);
                        }
                        if (segmentsEqualToFour == 3 && segmentsEqualToSeven == 2)
                        {
                            mapping.Add(pattern, 5);
                        }
                        break;

                    // 0, 6 or 9
                    case 6:
                        if (segmentsEqualToFour == 3 && segmentsEqualToSeven == 3)
                        {
                            mapping.Add(pattern, 0);
                        }
                        if (segmentsEqualToFour == 3 && segmentsEqualToSeven == 2)
                        {
                            mapping.Add(pattern, 6);
                        }
                        if (segmentsEqualToFour == 4 && segmentsEqualToSeven == 3)
                        {
                            mapping.Add(pattern, 9);
                        }
                        break;
                }
            }


            return mapping;
        }
    }
}
