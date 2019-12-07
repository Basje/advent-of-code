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

            var firstHalfResult = program.Run();

            int verb;
            int noun = -1;

            for (verb = 0; verb < 100; verb++)
            {
                for (noun = 0; noun < 100; noun++)
                {
                    program = IntcodeProgram.FromString(intcodeProgram);

                    program.Replace(1, noun);
                    program.Replace(2, verb);

                    if (program.Run() == 19690720) goto Result;
                }
            }

            Result:
            ShowResult(firstHalfResult, verb, noun);
        }

        private static void ShowHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Day 2");
            Console.WriteLine("-----");
            Console.WriteLine();
        }

        private static void ShowResult(int firstHalfResult, int verb, int noun)
        {
            Console.WriteLine($"1202: {firstHalfResult}");
            Console.WriteLine($"Verb: {verb}");
            Console.WriteLine($"Noun: {noun}");
        }
    }
}
