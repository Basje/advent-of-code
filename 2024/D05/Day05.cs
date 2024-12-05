namespace Basje.AdventOfCode.Y2024.D05;

public class Day05 : Solution<(string[] PageOrderingRules, string[][] PagesPerUpdate)>
{
    protected override (string[] PageOrderingRules, string[][] PagesPerUpdate) ParseInput(string input)
    {
        var data = input
            .PerBlock()
            .IgnoreEmptyLines()
            .Select(block => block.PerLine().IgnoreEmptyLines())
            .ToArray();
            
        return (
            PageOrderingRules: data[0]
                .ToArray(),
            PagesPerUpdate: data[1]
                .Select(update => update
                    .Split(",")
                    .ToArray()
                )
                .ToArray()
        );
    }

    protected override object SolvePart1((string[] PageOrderingRules, string[][] PagesPerUpdate) input)
    {
        var middlePageSum = 0;

        foreach (var update in input.PagesPerUpdate)
        {
            var valid = true; 
            
            for (var current = 0; valid && current < update.Length; current++)
            {
                for (var next = current + 1; valid && next < update.Length; next++)
                {
                    var check = $"{update[next]}|{update[current]}";
                    if (input.PageOrderingRules.Contains(check))
                    {
                        valid = false;
                        middlePageSum += int.Parse(update[(update.Length - 1) / 2]);
                    }
                }
            }
        }

        return middlePageSum;
    }

    protected override object SolvePart2((string[] PageOrderingRules, string[][] PagesPerUpdate) input)
    {
        var middlePageSum = 0;

        foreach (var update in input.PagesPerUpdate)
        {
            var newUpdate = update;
            var valid = true; 
            
            for (var current = 0; current < newUpdate.Length; current++)
            {
                var corrected = false;
                
                for (var next = current + 1; !corrected && next < newUpdate.Length; next++)
                {
                    var currentNumber = newUpdate[current];
                    var nextNumber = newUpdate[next];
                    var check = $"{nextNumber}|{currentNumber}";
                    if (input.PageOrderingRules.Contains(check))
                    {
                        valid = false;
                        corrected = true;

                        newUpdate = [..newUpdate[..current], nextNumber, ..newUpdate[current..next],..newUpdate[(next+1)..]];
                        current = 0;
                    }
                }
            }

            if (valid) continue;
            
            var middle = int.Parse(newUpdate[(newUpdate.Length - 1) / 2]);
            middlePageSum += middle;
        }

        return middlePageSum;
    }
}
