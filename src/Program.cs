using System;
using System.Linq;

namespace AdventOfCode_2019
{
    internal class Program
    {
        private const string DAY01_INPUT_LOCATION = @"Day-01\input.txt";
        private const string DAY02_INPUT_LOCATION = @"Day-02\input.txt";

        private static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2019");
            Console.WriteLine("===================");
            Console.WriteLine();

            Day_01.SubProgram.Run(InputProvider.GetIntegers(DAY01_INPUT_LOCATION));
            Day_02.SubProgram.Run(InputProvider.GetStrings(DAY02_INPUT_LOCATION).FirstOrDefault());
        }
    }
}
