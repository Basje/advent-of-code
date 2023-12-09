using Basje.AdventOfCode.Y2023.Input;

namespace Basje.AdventOfCode.Y2023.D09
{
    public class Day09 : Solution<Report>
    {
        protected override Report ParseInput(string input)
        {
            var histories = input
                .PerLine()
                .IgnoreEmptyLines()
                .Select(line => line.Split(' ').Select(int.Parse).ToList());

            return new Report() { Histories = histories };
        }

        protected override object SolvePart1(Report report)
        {
            var sum = 0;

            foreach (var history in report.Histories)
            {
                var sequences = new Stack<IList<int>>();
                var nextSequence = GetDifferencesList(history).ToList();

                while (nextSequence.Any(value => value != 0)) 
                {
                    sequences.Push(nextSequence.ToList());
                    nextSequence = GetDifferencesList(nextSequence).ToList();
                }

                var difference = sequences.Pop().Last();

                while (sequences.Count > 0)
                {
                    difference += sequences.Pop().Last();
                }
                
                sum += difference + history.Last();
            }
            return sum;
        }

        protected override object SolvePart2(Report report)
        {
            var sum = 0;

            foreach (var history in report.Histories)
            {
                var sequences = new Stack<IList<int>>();
                var nextSequence = GetDifferencesList(history).ToList();

                while (nextSequence.Any(value => value != 0))
                {
                    sequences.Push(nextSequence.ToList());
                    nextSequence = GetDifferencesList(nextSequence).ToList();
                }

                var difference = sequences.Pop().First();

                while (sequences.Count > 0)
                {
                    difference = sequences.Pop().First() - difference;
                }

                sum += history.First() - difference;
            }
            return sum;
        }

        private static IEnumerable<int> GetDifferencesList(IList<int> sequence) 
        {
            for (var i = 1; i < sequence.Count; i++)
            {
                yield return sequence[i] - sequence[i - 1];
            }
        }
    }
}
