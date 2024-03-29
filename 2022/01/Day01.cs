﻿namespace Basje.AdventOfCode.Y2022.D01;

public class Day01 : ISolution
{
    private readonly IEnumerable<int> caloriesPerElf;

    public Day01(string input)
    {
        caloriesPerElf = input
            // Split by empty line
            .Split("\n\n")
            // Split into calories per elf
            .Select(elfData => elfData
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse))
            // Calculate sum of calories per elf
            .Select(elfData => elfData.Sum());
    }

    public object SolvePart1()
    {
        // Most calories per elf
        return caloriesPerElf.Max();
    }

    public object SolvePart2()
    {
        return caloriesPerElf
            // Sort, most calories first
            .OrderDescending()
            // Only take the three elves with most calories
            .Take(3)
            // Calculate how much calories those elves have in total
            .Sum();
    }
}
