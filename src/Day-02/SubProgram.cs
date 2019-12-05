using System;
using System.Collections.Generic;

namespace AdventOfCode_2019.Day_02
{
    internal static class SubProgram
    {
        internal static void Run(string intcodeProgram)
        {
            ShowHeader();

            var program = IntcodeProgram.FromString(intcodeProgram);

            program.Replace(1, 12);
            program.Replace(2, 2);

            var result = program.Run();

            ShowResult(result);
        }

        private static void ShowHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Day 2");
            Console.WriteLine("-----");
            Console.WriteLine();
        }

        private static void ShowResult(int result)
        {
            Console.WriteLine($"Result: {result}");
        }
    }
}
