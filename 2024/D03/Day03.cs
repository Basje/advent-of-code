using System.Text.RegularExpressions;

namespace Basje.AdventOfCode.Y2024.D03;

public class Day03 : Solution<IEnumerable<string>>
{
    protected override IEnumerable<string> ParseInput(string input)
    {
        var multiplications = new Regex(@"do\(\)|don't\(\)|mul\(\d+,\d+\)");

        return multiplications
            .Matches(input)
            .Select(match => match.Value);
    }

    protected override object SolvePart1(IEnumerable<string> instructions)
    {
        return instructions
            .Select(instruction => instruction.MultiplicationValue())
            .Sum();
    }

    protected override object SolvePart2(IEnumerable<string> instructions)
    {
        var active = true;
        var result = 0;
        
        foreach (var instruction in instructions)
        {
            (result, active) = (instruction, active) switch
            {
                ("do()", _) => (result, true),
                ("don't()", _) => (result, false),
                (_, true) => (result + instruction.MultiplicationValue(), active),
                (_, _) => (result, active)
            };
        }
        
        return result;
    }
}

internal static class Day03Extensions {

    internal static int MultiplicationValue(this string instruction)
    {
        if (!instruction.StartsWith("mul")) return default;

        var numbers = instruction
            .Replace("mul(", "")
            .Replace(")", "")
            .Split(',')
            .Select(int.Parse)
            .ToArray();

        return numbers[0] * numbers[1];
    }
}
