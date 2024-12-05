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
        return input
            .PagesPerUpdate
            .Where(pages => pages.AreSorted(input.PageOrderingRules.ToComparer()))
            .Select(pages => int.Parse(pages[(pages.Length - 1) / 2]))
            .Sum();
    }

    protected override object SolvePart2((string[] PageOrderingRules, string[][] PagesPerUpdate) input)
    {
        var comparer = input.PageOrderingRules.ToComparer();

        return input
            .PagesPerUpdate
            .Where(pages => !pages.AreSorted(comparer))
            .Select(pages => pages.OrderBy(p => p, comparer).ToArray())
            .Select(pages => int.Parse(pages[(pages.Length - 1) / 2]))
            .Sum();
    }
}

internal static class Day05Extensions
{
    internal static Comparer<string> ToComparer(this string[] order)
    {
        return Comparer<string>.Create((left, right) => order.Contains($"{left}|{right}") ? -1 : 1);
    }

    internal static bool AreSorted(this string[] pages, Comparer<string> comparer)
    {
        return pages.SequenceEqual(pages.OrderBy(update => update, comparer));
    }
}
