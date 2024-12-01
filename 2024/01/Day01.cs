using System.Text.RegularExpressions;
using Basje.AdventOfCode.Y2024.Input;

namespace Basje.AdventOfCode.Y2024.D01;

public class Day01 : Solution<(int Left, int Right)[]>
{
    protected override (int Left, int Right)[] ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .SelectMany(line => line.Split("   "))
            .Select(int.Parse)
            .Chunk(2)
            .Select(pair => (Left: pair[0], Right: pair[1]))
            .ToArray();
    }
    
    protected override object SolvePart1((int Left, int Right)[] input)
    {
        var left = input.Select(pair => pair.Left).Order();
        var right = input.Select(pair => pair.Right).Order();

        return left.Zip(right, (l, r) => Math.Abs(l - r)).Sum();
    }

    protected override object SolvePart2((int Left, int Right)[] input)
    {
        var left = input.Select(pair => pair.Left);
        var right = input.Select(pair => pair.Right);

        return left.Aggregate(0, (similarity, number) => similarity + number * right.Count(r => r == number));
    }
}
