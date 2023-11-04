using System.Diagnostics;

namespace Basje.AdventOfCode.Y2022.D12;

public class Day12 : ISolution
{
    private readonly Square[,] map;

    public Day12(string input)
    {
        var marks = input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var horizontal = marks.First().Length;
        var vertical = marks.Count;
        var grid = new Square[horizontal, vertical];

        for (int y = 0; y < vertical; y++)
        {
            for (int x = 0; x < horizontal; x++)
            {
                var mark = marks[y][x];
                var height = mark switch
                {
                    >= 'a' and <= 'z' => mark - 'a',
                    'S' => 'a' - 'a',
                    'E' => 'z' - 'a',
                    _ => throw new Exception()
                };
                grid[x, y] = new Square {
                     X = x,
                     Y = y,
                     Height = height,
                     IsStart = mark == 'S',
                     IsEnd = mark == 'E',
                };
            }
        }
        map = grid;
    }

    public object SolvePart1()
    {
        var start = map.Squares().Single(s => s.IsStart);
        var end = map.Squares().Single(s => s.IsEnd);
        var pathLength = 0;

        start.Distance = 0;

        while (end.Distance == int.MaxValue)
        {
            foreach (var current in map.WithDistance(pathLength))
            {
                var availableNeighbours = map.NeighboursOf(current);

                foreach (var square in availableNeighbours)
                {
                    square.Distance = Math.Min(current.Distance + 1, square.Distance);
                }
            }
            pathLength++;
        }

        return end.Distance;
    }

    public object SolvePart2()
    {
        var starts = map.Squares().Where(s => s.Height == 0);
        var end = map.Squares().Single(s => s.IsEnd);
        var pathLengths = new List<int>() { int.MaxValue };

        foreach (var start in starts)
        {
            map.Reset();
            start.Distance = 0;
            var currentPathLength = 0;

            while (end.Distance == int.MaxValue && currentPathLength <= pathLengths.Min())
            {
                foreach (var current in map.WithDistance(currentPathLength))
                {
                    var availableNeighbours = map.NeighboursOf(current);

                    foreach (var square in availableNeighbours)
                    {
                        square.Distance = Math.Min(current.Distance + 1, square.Distance);
                    }
                }
                currentPathLength++;
            }

            if (end.Distance == int.MaxValue) continue;
            pathLengths.Add(end.Distance);
        }
        return pathLengths.Min();
    }
}

[DebuggerDisplay("( {X}, {Y} ) ↥{Height} △{Distance}")]
public record Square
{
    public required int X { get; init; }
    public required int Y { get; init; }
    public required int Height { get; init; }
    public required bool IsStart { get; init; } = false;
    public required bool IsEnd { get; init; } = false;

    public int Distance { get; set; } = int.MaxValue;
}

public static class Extensions
{
    public static IEnumerable<Square> Squares(this Square[,] map)
    {
        foreach (var square in map)
        {
            yield return square;
        }
    }

    public static IEnumerable<Square> NeighboursOf(this Square[,] map, Square current)
    {
        for (int x = Math.Max(0, current.X - 1); x <= Math.Min(map.GetLength(0) - 1, current.X + 1); x++)
        {
            for (int y = Math.Max(0, current.Y - 1); y <= Math.Min(map.GetLength(1) - 1, current.Y + 1); y++)
            {
                var neightbour = map[x, y];
               
                if (neightbour == current) continue;
                if (neightbour.Distance <= current.Distance) continue;
                if (neightbour.Height > current.Height + 1) continue;
                if (neightbour.X != current.X && neightbour.Y != current.Y) continue;

                yield return neightbour;
            }
        }
    }

    public static IEnumerable<Square> WithDistance(this Square[,] map, int distance)
    {
        foreach (var square in map)
        {
            if (square.Distance != distance) continue;
            yield return square;
        }
    }

    public static void Reset(this Square[,] map)
    {
        foreach (var square in map)
        {
            square.Distance = int.MaxValue;
        }
    }
}
