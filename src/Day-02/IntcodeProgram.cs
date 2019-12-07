using System;
using System.Collections.Generic;

namespace AdventOfCode_2019.Day_02
{
    public class IntcodeProgram
    {
        private const int INSTRUCTION_SIZE = 4;

        private int Index = 0;
        private Opcodes Opcode = Opcodes.Unknown;
        private int Result = 0;

        public IntcodeProgram(List<int> intCodes)
        {
            Memory = new Memory(intCodes);
        }

        private Memory Memory { get; }

        public void Replace(int position, int number)
        {
            Memory.SetAddress(position, number);
        }

        public int Run()
        {
            if (Result > 0) return Result;

            while (Opcode != Opcodes.EndProgram)
            {
                DoOperation(NextInstruction());
            }

            Result = Memory.GetAddress(0);

            return Result;
        }

        private void DoOperation(IList<int> instruction)
        {
            Opcode = (Opcodes)instruction[0];

            if (Opcode == Opcodes.EndProgram) return;

            var leftArgument = Memory.GetAddress(instruction[1]);
            var rightArgument = Memory.GetAddress(instruction[2]);
            var storageIndex = instruction[3];

            var instructionResult = Opcode switch
            {
                Opcodes.Add => leftArgument + rightArgument,

                Opcodes.Multiply => leftArgument * rightArgument,

                _ => throw new Exception($"Unknown opcode: {instruction[0]}"),
            };

            Memory.SetAddress(storageIndex, instructionResult);
        }

        private IList<int> NextInstruction()
        {
            var startLocation = Index * INSTRUCTION_SIZE;

            Index++;

            return Memory.GetAddressRange(startLocation, INSTRUCTION_SIZE);
        }
    }
}
