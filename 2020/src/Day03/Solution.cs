using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode_2020.Day03
{
    [Command("day-3", Description = "Toboggan Trajectory")]
    public class Solution : Puzzle
    {
        public Solution(CommandLineApplication app) : base(app)
        {
        }

        protected override Task<int> Solve()
        {
            var inputProvider = new InputProvider<string>(3, 1);
            var inputs = inputProvider.GetInputs();

            long multiplication = 1;

            var treeCount = CountTrees(inputs, 1, 1);
            multiplication *= treeCount;

            treeCount = CountTrees(inputs, 3, 1);
            multiplication *= treeCount;

            Console.WriteLine($"Day 03 part 1: {treeCount}");

            treeCount = CountTrees(inputs, 5, 1);
            multiplication *= treeCount;

            treeCount = CountTrees(inputs, 7, 1);
            multiplication *= treeCount;

            treeCount = CountTrees(inputs, 1, 2);
            multiplication *= treeCount;

            Console.WriteLine($"Day 03 part 2: {multiplication}");
            return Task.FromResult(0);
        }

        private int CountTrees(IList<string> map, int stepRight, int stepDown)
        {
            var mapHeight = map.Count;
            var treeCount = 0;

            for (int x = 0, y = 0; y < mapHeight; x += stepRight, y += stepDown)
            {
                if (map.IsTree(x, y))
                {
                    treeCount++;
                }
            }

            return treeCount;
        }
    }
}