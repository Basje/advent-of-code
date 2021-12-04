using System.Linq;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode_2020.Day05
{
    [Command("day-5", Description = "Binary Boarding")]
    public class Solution : Puzzle
    {
        public Solution(CommandLineApplication app) : base(app)
        {
        }

        protected override Task<int> Solve()
        {
            var inputProvider = new InputProvider<string>(5, 1);
            var inputs = inputProvider.GetInputs();

            var seatIds = inputs
                .ToBinaryString()
                .ToSeatIds();

            var highestSeatId = seatIds.Max();

            WriteHeaderLine("Day 5; part 1");
            WriteSuccessLine($"Highest seat ID is {highestSeatId}");
            WriteLine();

            var lowestSeatId = seatIds.Min();
            var availableSeatIds = Enumerable.Range(lowestSeatId, highestSeatId - lowestSeatId + 1).ToList();
            var freeSeatId = availableSeatIds.Except(seatIds).Single();

            WriteHeaderLine("Day 5; part 2");
            WriteSuccessLine($"Free seat ID is {freeSeatId}");

            return Task.FromResult(0);
        }
    }
}