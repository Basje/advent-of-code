namespace Basje.AdventOfCode.Y2022.D01
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
            return string.Empty;
        }

        public string SolvePart2()
        {
            return string.Empty;
        }

        static int ToInt(string input)
        {
            return int.Parse(input);
        }
    }
}
