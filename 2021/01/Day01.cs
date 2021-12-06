namespace Basje.AdventOfCode.Y2021.D01
{
    public class Day01 : ISolution
    {
        private readonly IEnumerable<int> depths;

        public Day01(IEnumerable<string> input)
        {
            depths = input.Select(ToInt);
        }

        public string SolvePart1()
        {
            var answer = depths
                .SlidingWindow(2)
                .Count(window => window.Last() > window.First());

            return answer.ToString();
        }

        public string SolvePart2()
        {
            var answer = depths
                .SlidingWindow(4)
                .Count(window => window.Last() > window.First());

            return answer.ToString();
        }

        static int ToInt(string input)
        {
            return int.Parse(input);
        }
    }
}
