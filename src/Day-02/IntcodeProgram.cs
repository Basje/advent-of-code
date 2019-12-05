using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2019.Day_02
{
    public class IntcodeProgram
    {
        private const int INSTRUCTION_SIZE = 4;

        private int Index = 0;
        private Opcodes Opcode = Opcodes.Unknown;
        private int Result = 0;

        private IntcodeProgram(List<int> intCodes)
        {
            IntCodes = intCodes;
        }

        private List<int> IntCodes { get; }

        public static IntcodeProgram FromString(string intCodes)
        {
            if (string.IsNullOrWhiteSpace(intCodes)) throw new ArgumentNullException(nameof(intCodes));

            var codes = intCodes.Split(',').Select(code => int.Parse(code)).ToList();

            return new IntcodeProgram(codes);
        }

        public bool Replace(int position, int number)
        {
            if (position >= IntCodes.Count) return false;

            IntCodes[position] = number;

            return true;
        }

        public int Run()
        {
            if (Result > 0) return Result;

            while (Opcode != Opcodes.EndProgram)
            {
                DoOperation(NextInstruction());
            }

            Result = IntCodes[0];

            return Result;
        }

        private void DoOperation(List<int> instruction)
        {
            Opcode = (Opcodes)instruction[0];

            if (Opcode == Opcodes.EndProgram) return;

            var leftArgument = IntCodes[instruction[1]];
            var rightArgument = IntCodes[instruction[2]];
            var storageIndex = instruction[3];

            var instructionResult = Opcode switch
            {
                Opcodes.Add => leftArgument + rightArgument,

                Opcodes.Multiply => leftArgument * rightArgument,

                _ => throw new Exception($"Unknown opcode: {instruction[0]}"),
            };

            IntCodes[storageIndex] = instructionResult;
        }

        private List<int> NextInstruction()
        {
            var startLocation = Index * INSTRUCTION_SIZE;
            var instructionSize = Math.Min(IntCodes.Count - startLocation, INSTRUCTION_SIZE);
            var instruction = IntCodes.GetRange(startLocation, instructionSize);

            Index++;

            return instruction;
        }
    }
}
