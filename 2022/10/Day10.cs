﻿using System.Text;

namespace Basje.AdventOfCode.Y2022.D10;

public class Day10 : ISolution
{
    private readonly IEnumerable<IInstruction> instructions;

    public Day10(string input)
    {
        instructions = input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(instruction => instruction.ParseInstruction());
    }

    public object SolvePart1()
    {
        var cpu = new Cpu();
        var signalStrengths = new List<int>();
        var instructions = new Queue<IInstruction>(this.instructions);

        while (instructions.Any())
        {
            // Check for signal strength
            if (cpu.Cycle % 40 == 20)
            {
                signalStrengths.Add(cpu.Cycle * cpu.X);
            }

            if (cpu.IsFree)
            {
                cpu.Process(instructions.Dequeue());
            }

            cpu.Tick();
        }

        return signalStrengths.Sum();
    }

    public object SolvePart2()
    {
        const int SCREEN_WIDTH = 40;
        var cpu = new Cpu();
        var screen = new StringBuilder();
        var instructions = new Queue<IInstruction>(this.instructions);
        var sprite = Enumerable.Repeat('.', SCREEN_WIDTH).ToList();

        while (instructions.Any())
        {
            for (var pixel = 0; pixel < sprite.Count(); pixel++)
            {
                sprite[pixel] = cpu.X - 1 <= pixel && pixel <= cpu.X + 1 ? '#' : '.';
            }

            screen.Append(sprite[(cpu.Cycle - 1) % SCREEN_WIDTH]);

            if (cpu.Cycle % SCREEN_WIDTH == 0)
            {
                screen.AppendLine();
            }

            if (cpu.IsFree)
            {
                cpu.Process(instructions.Dequeue());
            }

            cpu.Tick();
        }

        return screen;
    }
}

public interface IInstruction
{
    public int ApplyTo(int register);
}

public record Noop : IInstruction
{
    public int ApplyTo(int register) => register;
}

public record AddX : IInstruction
{
    public required int Value { get; init; }

    public int ApplyTo(int register) => register + Value;
}


public class Cpu
{
    private IInstruction? instruction;
    private int requiredProcessingCycles = 0;

    public int X { get; private set; } = 1;
    public int Cycle { get; private set; } = 1;
    public bool IsFree => instruction == null;

    public void Process(IInstruction instruction)
    {
        this.instruction = instruction;
        requiredProcessingCycles = instruction switch
        {
            _ when instruction is Noop => 1,
            _ when instruction is AddX => 2,
            _ => 0,
        };
    }

    public void Tick()
    {
        Cycle++;
        requiredProcessingCycles = Math.Max(0, --requiredProcessingCycles);
        if (requiredProcessingCycles == 0)
        {
            X = instruction?.ApplyTo(X) ?? X;
            instruction = null;
        }
    }
}

public static class Extensions
{
    public static IInstruction ParseInstruction(this string instruction)
    {
        return instruction switch
        {
            "noop" => new Noop(),
            _ when instruction.StartsWith("addx") => new AddX { Value = int.Parse(instruction.Split(' ').Last()) },
            _ => throw new Exception(),
        };
    }
}
