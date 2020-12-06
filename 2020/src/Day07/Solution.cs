using System.Linq;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode_2020.Day07
{
    [Command("day-7", Description = "?")]
    public class Solution : Puzzle
    {
        public Solution(CommandLineApplication app) : base(app)
        {
        }

        protected override Task<int> Solve()
        {
            var inputProvider = new InputProvider<string>(7, 1);
            var inputs = inputProvider.GetInputs();

            WriteHeaderLine("Day 7; part 1");
            WriteSuccessLine($"?");
            WriteLine();

            WriteHeaderLine("Day 7; part 2");
            WriteSuccessLine($"?");
            WriteLine();

            return Task.FromResult(0);
        }
    }
}