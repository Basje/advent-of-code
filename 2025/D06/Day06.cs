using System.Text.RegularExpressions;

namespace Basje.AdventOfCode.Y2025.D06;

public class Day06 : Solution<string[]>
{
    protected override string[] ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .ToArray();
    }
    
    protected override object SolvePart1(string[] lines)
    {
        var problems = lines
            .Select(line => Regex.Split(line, @"\s").IgnoreEmptyLines().ToArray())
            .ToArray();

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

    protected override object SolvePart2(string[] lines)
    {
        var grandTotal = 0L;
        var total = 0L;
        var operators = lines.Last();
        var numbers = lines.Take(lines.Length - 1).ToArray();
        var op = operators[0];

        for (var i = 0; i < operators.Length; i++)
        {
            var number = 0;

            if (operators[i] != ' ')
            {
                grandTotal += total;
                total = 0;
                op = operators[i];
            }

            for (var j = 0; j < numbers.Length; j++)
            {
                if (numbers[j][i] != ' ')
                {
                    number = number * 10 + (numbers[j][i] - '0');
                }
            }

            total = (op, total, number) switch
            {
                ('+', _, _) => total + number,
                ('*', 0, _) => number,
                ('*', _, 0) => total,
                ('*', _, _) => total * number,
                _ => throw new Exception($"Unknown operator {op}")
            };
        }

        grandTotal += total;

        return grandTotal;
    }
}
