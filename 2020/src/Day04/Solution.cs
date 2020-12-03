using System;
using System.Threading;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode_2020.Day04
{
    [Command("day-4", Description = "?")]
    public class Solution : Puzzle
    {
        public Solution(CommandLineApplication app) : base(app)
        {
        }

        public override Task<int> OnExecuteAsync(CommandLineApplication app, CancellationToken cancellationToken)
        {
            //var inputProvider = new InputProvider<string>(2, 1);
            //var inputs = inputProvider.GetInputs();

            return Task.FromResult(0);
        }
    }
}