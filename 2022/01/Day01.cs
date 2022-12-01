namespace Basje.AdventOfCode.Y2022.D01
{
    public class Day01 : ISolution
    {
        private readonly IEnumerable<string> lines;

        public Day01(IEnumerable<string> input)
        {
            lines = input;
        }

        public string SolvePart1()
        {
            var caloriesPerElf = 
                // Merge string back to original input
                string.Join('\n', lines)
                // Split by empty line
                .Split("\n\n")
                // Split into calories per elf
                .Select(elfData => elfData.Split('\n').Select(int.Parse))
                // Calculate sum of calories per elf
                .Select(elfData => elfData.Sum());

            return caloriesPerElf.Max().ToString();
        }

        public string SolvePart2()
        {
            var caloriesPerElf =
                // Merge string back to original input
                string.Join('\n', lines)
                // Split by empty line
                .Split("\n\n")
                // Split into calories per elf
                .Select(elfData => elfData.Split('\n').Select(int.Parse))
                // Calculate sum of calories per elf
                .Select(elfData => elfData.Sum())
                // Sort, most calories first
                .OrderDescending()
                // Only take the three elves with most calories
                .Take(3);

            return caloriesPerElf.Sum().ToString();
        }
    }
}
