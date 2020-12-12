using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode_2020.Day07
{
    [Command("day-7", Description = "Handy Haversacks")]
    public class Solution : Puzzle
    {
        public Solution(CommandLineApplication app) : base(app)
        {
        }

        protected override Task<int> Solve()
        {
            var inputProvider = new InputProvider<string>(7, 1);
            var inputs = inputProvider.GetInputs();
            var translationTable = inputs.DetermineBagTypes();
            var bagProperties = inputs.DetermineBagContentsWith(translationTable);
            var shinyGoldBagId = translationTable["shiny gold"];

            WriteVerboseLine($"Found {translationTable.Count} colors of bags.");
            WriteVerboseLine($"Shiny gold bag has ID {shinyGoldBagId}");

            var results = new Dictionary<int, bool>();

            foreach (var bag in bagProperties)
            {
                results[bag.Key] = CanHold(bag.Key, shinyGoldBagId, bagProperties, results);
            }

            var bagCount = results.Count(result => result.Value);

            WriteHeaderLine("Day 7; part 1");
            WriteSuccessLine($"There are {bagCount} bags that can hold a shiny gold bag.");
            WriteLine();

            WriteHeaderLine("Day 7; part 2");
            WriteSuccessLine($"?");
            WriteLine();

            return Task.FromResult(0);
        }

        private static bool CanHold(int currentBag, int requiredBag, IDictionary<int, IDictionary<int, int>> properties, IDictionary<int, bool> result)
        {
            if (result.ContainsKey(currentBag))
            {
                return result[currentBag];
            }

            if (properties[currentBag].Count == 0)
            {
                //result[currentBag] = false;
                return false;
            }

            if (properties[currentBag].ContainsKey(requiredBag))
            {
                //result[currentBag] = true;
                return true;
            }

            return properties[currentBag].Any(subBag => CanHold(subBag.Key, requiredBag, properties, result));
        }
    }
}