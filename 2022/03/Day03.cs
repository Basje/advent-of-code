namespace Basje.AdventOfCode.Y2022.D03;

public class Day03 : ISolution
{
    private readonly IEnumerable<string> rucksacks;

    public Day03(string input)
    {
        rucksacks = input
            // Split into separate rucksacks
            .Split('\n', StringSplitOptions.RemoveEmptyEntries);
    }

    public long SolvePart1()
    {
        return rucksacks
            // Split rucksacks into two equal compartments
            .Select(rucksack => (
                left: rucksack[..(rucksack.Length / 2)],
                right: rucksack[(rucksack.Length / 2)..])
            )
            // Get the item from both compartments
            .Select(rucksack => rucksack.left.Intersect(rucksack.right).Single())
            // Determine priority of items
            .Select(item => item.PriorityValue())
            // Get sum of all priorities
            .Sum();
    }

    public long SolvePart2()
    {
        return rucksacks
            // Divide into groups of three elves
            .Chunk(3)
            // Find the common item within each group
            .Select(group => group[0].Intersect(group[1]).Intersect(group[2]).Single())
            // Determine priority of items
            .Select(item => item.PriorityValue())
            // Get sum of all priorities
            .Sum();
    }
}

public static class Extensions
{
    public static int PriorityValue(this char item)
    {
        return item switch
        {
            >= 'a' and <= 'z' => item - 'a' + 1,
            >= 'A' and <= 'Z' => item - 'A' + 27,
            _ => throw new ArgumentException()
        };
    }
}
