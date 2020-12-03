using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode_2020
{
    internal class Program
    {
        private static int CountTrees(IList<string> map, int stepRight, int stepDown)
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

        private static void Main(string[] args)
        {
            //SolveDay01();
            //SolveDay02();
            SolveDay03();
        }

        private static void SolveDay01()
        {
            var inputProvider = new InputProvider<int>(1, 1);
            var inputs = inputProvider.GetInputs();

            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = i + 1; j < inputs.Count; j++)
                {
                    var left = inputs[i];
                    var right = inputs[j];
                    var sum = left + right;

                    if (sum == 2020)
                    {
                        Console.WriteLine($"Day 01 part 1: {left * right}");
                    }
                }
            }

            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = i + 1; j < inputs.Count; j++)
                {
                    for (int k = i + 2; k < inputs.Count; k++)
                    {
                        var left = inputs[i];
                        var middle = inputs[j];
                        var right = inputs[k];
                        var sum = left + middle + right;

                        if (sum == 2020)
                        {
                            Console.WriteLine($"Day 01 part 2: {left * middle * right}");
                        }
                    }
                }
            }
        }

        private static void SolveDay02()
        {
            var inputProvider = new InputProvider<string>(2, 1);
            var inputs = inputProvider.GetInputs();
            var regex = new Regex(@"^(\d+)-(\d+) (\w): (\w+)$");
            var correctSledRentalPlacePasswordCount = 0;
            var correctTobogganCasPasswordCount = 0;

            foreach (var input in inputs)
            {
                var matches = regex.Match(input);

                if (!matches.Success)
                {
                    continue;
                }

                var minumum = (int)Convert.ChangeType(matches.Groups[1].Value, typeof(int));
                var maximum = (int)Convert.ChangeType(matches.Groups[2].Value, typeof(int));
                var character = matches.Groups[3].Value;
                var password = matches.Groups[4].Value;
                var occurences = Regex.Matches(password, character).Count;

                if (minumum <= occurences && occurences <= maximum)
                {
                    correctSledRentalPlacePasswordCount++;
                }

                var positionalOccurences = 0;

                if (password[minumum - 1].ToString() == character)
                {
                    positionalOccurences++;
                }

                if (password[maximum - 1].ToString() == character)
                {
                    positionalOccurences++;
                }

                if (positionalOccurences == 1)
                {
                    correctTobogganCasPasswordCount++;
                }
            }

            Console.WriteLine($"Day 02 part 1: {correctSledRentalPlacePasswordCount}");
            Console.WriteLine($"Day 02 part 2: {correctTobogganCasPasswordCount}");
        }

        private static void SolveDay03()
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
        }
    }
}