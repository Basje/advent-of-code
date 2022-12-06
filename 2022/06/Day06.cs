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
        // We start with 3 characters in the buffer
        var buffer = 3;
        // Look at each series of 4 characters from start to end
        foreach (var window in datastream.SlidingWindow(4))
        {
            // Keep track of our location
            buffer++;
            // Did we find a start-of-packet marker?
            if (window.Distinct().Count() == 4)
            {
                return buffer;
            }
        }
        // Error :(
        return -1;
    }

    public object SolvePart2()
    {
        // We start with 13 characters in the buffer
        var buffer = 13;
        // Look at each series of 4 characters from start to end
        foreach (var window in datastream.SlidingWindow(14))
        {
            // Keep track of our location
            buffer++;
            // Did we find a start-of-message marker?
            if (window.Distinct().Count() == 14)
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
