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
        return FindMarkerOfLength(4);
    }

    public object SolvePart2()
    {
        return FindMarkerOfLength(14);
    }

    private int FindMarkerOfLength(int length)
    {
        // We start with a buffer to get the required number of characters
        var buffer = length - 1;
        // Look at each series of specified length from start to end
        foreach (var window in datastream.SlidingWindow(length))
        {
            // Keep track of our location
            buffer++;
            // Did we find a marker?
            if (window.Distinct().Count() == length)
            {
                return buffer;
            }
        }
        // Error :(
        return -1;
    }
}

public static class Extensions
{
    // Reuse extension from 2021 day 1
    public static IEnumerable<ArraySegment<T>> SlidingWindow<T>(this IEnumerable<T> list, int size)
    {
        size = Math.Max(1, size);
        var array = list.ToArray();

        for (var i = 0; i <= list.Count() - size; i++)
        {
            yield return new ArraySegment<T>(array, i, size);
        }
    }
}
