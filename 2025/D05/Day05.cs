namespace Basje.AdventOfCode.Y2025.D05;

public class Day05 : Solution<Day05.Database>
{
    public readonly record struct Range(long Min, long Max);
    public readonly record struct Database(Range[] Fresh, long[] IDs);
    
    protected override Database ParseInput(string input)
    {
        var data = input
            .PerBlock()
            .Select(block => block.PerLine().ToArray()).ToArray();

        var ranges = data[0]
            .IgnoreEmptyLines()
            .Select(line => line.Split("-").Select(long.Parse).ToArray())
            .Select(line => new Range(line[0], line[1]))
            .ToArray();

        var ids = data[1]
            .IgnoreEmptyLines()
            .Select(long.Parse)
            .ToArray();
        
        return new Database(ranges, ids);
    }
    
    protected override object SolvePart1(Database database)
    {
        return database.IDs.Count(id => database.Fresh.Any(range => range.Min <= id && id <= range.Max));
    }

    protected override object SolvePart2(Database database)
    {
        var orderedRanges = database.Fresh.OrderBy(range => range.Min).ToArray();
        var mergedRanges = new List<Range>();
        Range currentRange;

        for (var i = 0; i < orderedRanges.Count(); i++)
        {
            currentRange = orderedRanges[i];
            var currentIndex = i;
            
            for (var j = currentIndex + 1; j < orderedRanges.Length; j++)
            {
                if (orderedRanges[j].Min <= currentRange.Max + 1)
                {
                    currentRange = new Range(currentRange.Min, Math.Max(currentRange.Max, orderedRanges[j].Max));
                    i++;
                }
                else
                {
                    mergedRanges.Add(currentRange);
                    currentRange = default;
                    break;
                }
            }

            if (currentRange != default)
            {
                mergedRanges.Add(currentRange);
            }
        }

        var count = 0L;
        foreach (var range in mergedRanges)
        {
            count += range.Max - range.Min + 1;
        }
        
        return count;
    }
}
