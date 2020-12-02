using System;

namespace AdventOfCode_2020
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SolveDay01();
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
    }
}