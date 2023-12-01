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
        return input
            // Remove non-numeric characters    
            .Select(line => Regex.Replace(line, "[a-z]", ""))
            // Take first and last number
            .Select(line => $"{line.First()}{line.Last()}")
            // Convert to integer
            .Select(int.Parse)
            // Calculate total sum
            .Sum();
    }

    protected override object SolvePart2(IEnumerable<string> input)
    {
        // List all replaces. We don't care about the resulting string, only that we find the first and last number
        // that is spelled out. Some spellings might overlap, for example "eightwo". To account for this, the
        // replacements keep those possible overlapping characters intact. Full list of overlaps is:
        // - oneight => 1e, e8
        // - twone => o1, 2o
        // - threeight => 3e, e8
        // - fiveight => 5e, e8
        // - sevenine => 7n, n9
        // - eightwo, eighthree => 8t, t2, t3
        // - nineight => e8, 9e
        var replaces = new Dictionary<string, string>()
        {
            {"one", "o1e"},
            {"two", "t2o"},
            {"three", "t3e"},
            {"four", "4"},
            {"five", "5e"},
            {"six", "6"},
            {"seven", "7n"},
            {"eight", "e8t"},
            {"nine", "n9e"},
        };
            
        return input
            // Replace spelled out numbers with numeric characters     
            .Select(line => replaces.Aggregate(line, (current, replace) => current.Replace(replace.Key, replace.Value)))
            // Remove non-numeric characters
            .Select(line => Regex.Replace(line, "[a-z]", ""))
            // Take first and last number
            .Select(line => $"{line.First()}{line.Last()}")
            // Convert to integer
            .Select(int.Parse)
            // Calculate total sum
            .Sum();
    }
}
