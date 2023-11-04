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
        var scenicScores = new int[trees.GetLength(0),trees.GetLength(1)];

        foreach (var currentTree in trees)
        {
            scenicScores[currentTree.X, currentTree.Y] =
                trees.Above(currentTree).ViewingDistance(currentTree.Height)
                * trees.Below(currentTree).ViewingDistance(currentTree.Height)
                * trees.RightOf(currentTree).ViewingDistance(currentTree.Height)
                * trees.LeftOf(currentTree).ViewingDistance(currentTree.Height);
        }

        return scenicScores.All().Max();
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

    public static int ViewingDistance(this IEnumerable<Tree> trees, int height)
    {
        var distance = 0;
        foreach (var tree in trees)
        {
            distance++;
            if (tree.Height >= height) break;
        }
        return distance;
    }

    public static IEnumerable<int> All(this int[,] scores)
    {
        foreach (var score in scores)
        {
            yield return score;
        }
    }
}
