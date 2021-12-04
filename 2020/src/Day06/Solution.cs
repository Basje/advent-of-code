using System.Linq;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode_2020.Day06
{
    [Command("day-6", Description = "Custom Customs")]
    public class Solution : Puzzle
    {
        public Solution(CommandLineApplication app) : base(app)
        {
        }

        protected override Task<int> Solve()
        {
            var inputProvider = new InputProvider<string>(6, 1);
            var inputs = inputProvider.GetInputs();

            var inputsPerGroup = inputs.ToAnswerDataPerGroup();
            var totalAnswersForAllGroups = inputsPerGroup.CountUniqueAnswersPerGroup().Sum();

            WriteHeaderLine("Day 6; part 1");
            WriteSuccessLine($"Sum of all answers given by ANY member of a group is {totalAnswersForAllGroups}");
            WriteLine();

            var totalUnanimousAnswersForAllGroups = inputsPerGroup.CountUnanimousAnswerPerGroup().Sum();

            WriteHeaderLine("Day 6; part 2");
            WriteSuccessLine($"Sum of all answers given by EVERY member of a group is {totalUnanimousAnswersForAllGroups}");
            WriteLine();

            return Task.FromResult(0);
        }
    }
}