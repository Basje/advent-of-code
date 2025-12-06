using System.Text.RegularExpressions;

namespace Basje.AdventOfCode.Y2025.D06;

public class Day06 : Solution<string[][]>
{
    protected override string[][] ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => Regex.Split(line, @"\s+").IgnoreEmptyLines().ToArray())
            .ToArray();
    }
    
    protected override object SolvePart1(string[][] problems)
    {
        var operators = problems.Last();
        var numbers = problems
            .Take(problems.Length - 1)
            .Select(line => line.Select(int.Parse).ToArray())
            .ToArray();
        var total = new long[numbers[0].Length];
        
        foreach (var line in numbers)
        {
            foreach (var (number, i) in line.Select((number, i) => (number, i)))
            {
                total[i] = operators[i] switch
                {
                    "+" => number + total[i],
                    "*" => total[i] == 0 ? number : number * total[i],
                    _ => throw new Exception($"Unknown operator {operators[i]}")
                };
            }
        }
        
        return total.Sum();
    }

    protected override object SolvePart2(string[][] problems)
    {
        return "X";
    }
}
