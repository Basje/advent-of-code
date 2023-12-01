using System.Text.RegularExpressions;
using Basje.AdventOfCode.Y2023.Input;

namespace Basje.AdventOfCode.Y2023.D01;

public class Day01 : Solution<IEnumerable<string>>
{
    protected override IEnumerable<string> ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines();
    }
    
    protected override object SolvePart1(IEnumerable<string> input)
    {
        var lines = input
            .Select(line => Regex.Replace(line, "[a-z]", ""));

        var total = 0;
        
        foreach (var line in lines)
        {
            if (line.Length == 0) continue;
            var number = int.Parse($"{line.First()}{line.Last()}");
            total += number;
        }
        
        return total;
    }

    protected override object SolvePart2(IEnumerable<string> input)
    {
               

            // .Select(line => Regex.Replace(line, "[a-z]", ""));

        var total = 0;
        
        foreach (var line in input)
        {
            var line2 = line
                .Replace("one", "o1e")
                .Replace("two", "t2o")
                .Replace("three", "thr3e")
                .Replace("four", "f4ur")
                .Replace("five", "f5ve")
                .Replace("six", "s6x")
                .Replace("seven", "se7en")
                .Replace("eight", "eih8ht")
                .Replace("nine", "n9ne");
            
            line2 = Regex.Replace(line2, "[a-z]", "");
            
            var number = int.Parse($"{line2.First()}{line2.Last()}");
            total += number;
        }
        
        return total;    }
}
