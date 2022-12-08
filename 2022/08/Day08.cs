namespace Basje.AdventOfCode.Y2022.D08;

public class Day08 : ISolution
{
    private readonly Tree[,] trees;
    private readonly int northToSouth;
    private readonly int westToEast;

    public Day08(string input)
    {
        var heights = input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(row => row.Select(value => int.Parse(value.ToString())).ToArray())
            .ToArray();


        westToEast = heights.First().Length;
        northToSouth = heights.Count();

        trees = new Tree[westToEast, northToSouth];

        for (int y = 0; y < northToSouth; y++)
        {
            for (int x = 0; x < westToEast; x++)
            {
                trees[x, y] = new Tree
                {
                    Height = heights[y][x],
                    IsVisibleFromNorth = y == 0,
                    IsVisibleFromEast = x == westToEast - 1,
                    IsVisibleFromSouth = y == northToSouth - 1,
                    IsVisibleFromWest = x == 0,
                };
            }
        }
    }

    public object SolvePart1()
    {
        // Determine north to south
        for (int x = westToEast.First(); x <= westToEast.Last(); x++)
        {
            for (int y = northToSouth.First() + 1, maxHeight = trees[x, northToSouth.First()].Height; y <= northToSouth.Last(); y++)
            {
                trees[x, y].IsVisibleFromNorth = trees[x, y].Height > maxHeight;
                maxHeight = Math.Max(maxHeight, trees[x, y].Height);
            }
        }

        // Determine south to north
        for (int x = westToEast.Last(); x >= westToEast.First(); x--)
        {
            for (int y = northToSouth.Last() - 1, maxHeight = trees[x, northToSouth.Last()].Height; y >= northToSouth.First(); y--)
            {
                trees[x, y].IsVisibleFromSouth = trees[x, y].Height > maxHeight;
                maxHeight = Math.Max(maxHeight, trees[x, y].Height);
            }
        }

        // Determine west to east
        for (int y = northToSouth.First(); y <= northToSouth.Last(); y++)
        {
            for (int x = westToEast.First() + 1, maxHeight = trees[westToEast.First(), y].Height; x <= westToEast.Last(); x++)
            {
                trees[x, y].IsVisibleFromWest = trees[x, y].Height > maxHeight;
                maxHeight = Math.Max(maxHeight, trees[x, y].Height);
            }
        }

        // Determine east to west
        for (int y = northToSouth.Last(); y >= northToSouth.First(); y--)
        {
            for (int x = westToEast.Last() - 1, maxHeight = trees[westToEast.Last(), y].Height; x >= westToEast.First(); x--)
            {
                trees[x, y].IsVisibleFromEast = trees[x, y].Height > maxHeight;
                maxHeight = Math.Max(maxHeight, trees[x, y].Height);
            }
        }

        var visibleTrees = 0;
        foreach (var tree in trees)
        {
            if (tree.IsVisible)
            {
                visibleTrees++;
            }
        }

        return visibleTrees;
    }

    public object SolvePart2()
    {
        return -1;
    }
}

public record Tree
{
    public required int Height { get; init; }
    public required bool IsVisibleFromNorth { get; set; }
    public required bool IsVisibleFromEast { get; set; }
    public required bool IsVisibleFromSouth { get; set; }
    public required bool IsVisibleFromWest { get; set; }

    public bool IsVisible => IsVisibleFromNorth || IsVisibleFromEast || IsVisibleFromSouth || IsVisibleFromWest;
}

public static class Extensions
{
    public static int First(this int dimension)
    {
        return 0;
    }

    public static int Last(this int dimension)
    {
        return dimension - 1;
    }
}
