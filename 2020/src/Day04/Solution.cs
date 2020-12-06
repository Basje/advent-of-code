using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode_2020.Day04
{
    [Command("day-4", Description = "Passport Processing")]
    public class Solution : Puzzle
    {
        public Solution(CommandLineApplication app) : base(app)
        {
        }

        protected override Task<int> Solve()
        {
            var inputProvider = new InputProvider<string>(4, 1);
            var inputs = inputProvider.GetInputs();
            var naiveValidPassportCount = inputs.CountValidPassportsNaively();

            WriteHeaderLine("Day 4; part 1");
            WriteSuccessLine($"{naiveValidPassportCount} passports are valid");
            WriteLine();

            var properValidPassportCount = inputs.CountValidPassportsProperly();

            WriteHeaderLine("Day 4; part 2");
            WriteSuccessLine($"{properValidPassportCount} passports are valid");

            return Task.FromResult(0);
        }
    }
}