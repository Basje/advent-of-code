using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode_2020.Day01
{
    [Command("day01")]
    public class Solution : Puzzle
    {
        public Solution(CommandLineApplication app) : base(app)
        {
        }

        /// <summary>
        /// Searches for three values in the input list which have the specified sum.
        /// </summary>
        /// <param name="sum">The requested sum of the three values.</param>
        /// <param name="inputs">The integers that we can use.</param>
        /// <returns></returns>
        public int[] FindSumTriple(int sum, IList<int> inputs)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = i + 1; j < inputs.Count; j++)
                {
                    for (int k = i + 2; k < inputs.Count; k++)
                    {
                        var left = inputs[i];
                        var middle = inputs[j];
                        var right = inputs[k];

                        if (sum == left + middle + right)
                        {
                            return new int[] { left, middle, right };
                        }
                    }
                }
            }
            return Array.Empty<int>();
        }

        /// <summary>
        /// Searches for two values in the input list which have the specified sum.
        /// </summary>
        /// <param name="sum">The requested sum of the two values</param>
        /// <param name="inputs">The integers that we can use.</param>
        /// <returns></returns>
        public int[] FindSumTuple(int sum, IList<int> inputs)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = i + 1; j < inputs.Count; j++)
                {
                    var left = inputs[i];
                    var right = inputs[j];

                    if (sum == left + right)
                    {
                        return new int[] { left, right };
                    }
                }
            }
            return Array.Empty<int>();
        }

        public override Task<int> OnExecuteAsync(CommandLineApplication app, CancellationToken cancellationToken)
        {
            const int YEAR = 2020;

            var inputProvider = new InputProvider<int>(1, 1);
            var inputs = inputProvider.GetInputs();

            var firstResult = FindSumTuple(YEAR, inputs);
            var secondResult = FindSumTriple(YEAR, inputs);

            WriteHeaderLine("Day 1; part 1");
            WriteVerboseLine($"{firstResult[0]} + {firstResult[1]} = {firstResult[0] + firstResult[1]}");
            WriteSuccessLine($"{firstResult[0]} * {firstResult[1]} = {firstResult[0] * firstResult[1]}");

            WriteLine();

            WriteHeaderLine("Day 1; part 2");
            WriteVerboseLine($"{secondResult[0]} + {secondResult[1]} * {secondResult[2]} = {secondResult[0] + secondResult[1] + secondResult[1]}");
            WriteSuccessLine($"{secondResult[0]} * {secondResult[1]} * {secondResult[2]} = {secondResult[0] * secondResult[1] * secondResult[1]}");
            return Task.FromResult(0);
        }
    }
}