namespace Basje.AdventOfCode.Y2022.D06;

public class Day06 : ISolution
{
    private readonly IEnumerable<char> datastream;

    public Day06(string input)
    {
        datastream = input
            // Just to be sure, remove possible empty trailing lines
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            // We only want the first line, though
            .First()
            // Working on a collection is easier than using the string
            .ToArray();
    }

    public object SolvePart1()
    {
        return datastream.FindMarkerOfLength(4);
    }

    public object SolvePart2()
    {
        return datastream.FindMarkerOfLength(14);
    }
}

public static class Extensions
{
    // Reuse extension from 2021 day 1
    public static IEnumerable<(int index, ArraySegment<T> window)> SlidingWindow<T>(this IEnumerable<T> list, int size)
    {
        size = Math.Max(1, size);
        var array = list.ToArray();

        for (var i = 0; i <= list.Count() - size; i++)
        {
            yield return (index: i, window: new ArraySegment<T>(array, i, size));
        }
    }

    public static int FindMarkerOfLength(this IEnumerable<char> datastream, int length)
    {
        // Look at each series of specified length from start to end
        foreach (var (index, window) in datastream.SlidingWindow(length))
        {
            // Did we find a marker?
            if (window.Distinct().Count() == length)
            {
                return length + index;
            }
        }
        // Error :(
        return -1;
    }
}
