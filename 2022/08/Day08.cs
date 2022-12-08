namespace Basje.AdventOfCode.Y2022.D08;

public class Day08 : ISolution
{
    private readonly Tree[,] trees;

    public Day08(string input)
    {
        var heights = input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(row => row.Select(value => int.Parse(value.ToString())).ToArray())
            .ToArray();

        var westToEast = heights.First().Length;
        var northToSouth = heights.Length;

        trees = new Tree[westToEast, northToSouth];

        for (int y = 0; y < northToSouth; y++)
        {
            for (int x = 0; x < westToEast; x++)
            {
                trees[x, y] = new Tree
                {
                    X = x,
                    Y = y,
                    Height = heights[y][x],
                };
            }
        }
    }

    public object SolvePart1()
    {
        var visibleTrees = 0;

        foreach (var currentTree in trees)
        {
            if (trees.Above(currentTree).All(tree => tree.Height < currentTree.Height)
                || trees.Below(currentTree).All(tree => tree.Height < currentTree.Height)
                || trees.RightOf(currentTree).All(tree => tree.Height < currentTree.Height)
                || trees.LeftOf(currentTree).All(tree => tree.Height < currentTree.Height))
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
    public required int X { get; init; }
    public required int Y { get; init; }
}

public static class Extensions
{
    public static IEnumerable<Tree> Above(this Tree[,] trees, Tree tree)
    {
        for (int x = tree.X, y = tree.Y - 1; y >= 0; y--)
        {
            yield return trees[x, y];
        }
    }

    public static IEnumerable<Tree> Below(this Tree[,] trees, Tree tree)
    {
        for (int x = tree.X, y = tree.Y + 1; y < trees.GetLength(1); y++)
        {
            yield return trees[x, y];
        }
    }

    public static IEnumerable<Tree> LeftOf(this Tree[,] trees, Tree tree)
    {
        for (int x = tree.X - 1, y = tree.Y; x >= 0; x--)
        {
            yield return trees[x, y];
        }
    }

    public static IEnumerable<Tree> RightOf(this Tree[,] trees, Tree tree)
    {
        for (int x = tree.X + 1, y = tree.Y; x < trees.GetLength(0); x++)
        {
            yield return trees[x, y];
        }
    }
}
