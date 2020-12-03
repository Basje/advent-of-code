using McMaster.Extensions.CommandLineUtils;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode_2020
{
    [Command("aoc")]
    [Subcommand(
        typeof(Day01.Solution),
        typeof(Day02.Solution),
        typeof(Day03.Solution),
        typeof(Day04.Solution)
    )]
    internal class AdventOfCode : Puzzle
    {
        public AdventOfCode(CommandLineApplication app) : base(app)
        {
        }

        public override Task<int> OnExecuteAsync(CommandLineApplication app, CancellationToken cancellationToken)
        {
            app.ShowHint();
            return Task.FromResult(0);
        }

        private static async Task<int> Main(string[] args)
        {
            var app = new CommandLineApplication<AdventOfCode>();

            app.Conventions.UseDefaultConventions();

            try
            {
                return await app.ExecuteAsync(args);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                app.Error.WriteLine(e.Message);
                Console.ResetColor();
                return 1;
            }
        }
    }
}