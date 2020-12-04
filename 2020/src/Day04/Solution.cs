using System.Threading;
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

        public override Task<int> OnExecuteAsync(CommandLineApplication app, CancellationToken cancellationToken)
        {
            var inputProvider = new InputProvider<string>(4, 1);
            var inputs = inputProvider.GetInputs();

            var validPassportCount = inputs.CountValidPassports();

            WriteHeaderLine("Day 4; part 1");
            WriteSuccessLine($"{validPassportCount} passports are valid");

            return Task.FromResult(0);
        }
    }
}