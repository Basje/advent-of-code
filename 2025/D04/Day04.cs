namespace Basje.AdventOfCode.Y2025.D04;

public class Day04 : Solution<char[][]>
{
    protected override char[][] ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => line.ToCharArray())
            .ToArray();
    }
    
    protected override object SolvePart1(char[][] grid)
    {
        var reachableRolls = 0;
        foreach (var (row, y) in grid.Select((row, y) => (row, y)))
        {
            foreach (var (value, x) in row.Select((value, x) => (value, x)))
            {
                if (value == '.') continue;
                var neighbours = grid.GetNeighbours(x, y);
                if (neighbours.Count(position => position == '@') < 4) reachableRolls++;
            }
        }
        return reachableRolls;
    }

    protected override object SolvePart2(char[][] grid)
    {
        var totalReachableRolls = 0;
        List<(int X, int Y)> reachableRolls = [];
        do
        {
            reachableRolls.Clear();
            foreach (var (row, y) in grid.Select((row, y) => (row, y)))
            {
                foreach (var (value, x) in row.Select((value, x) => (value, x)))
                {
                    if (value == '.') continue;
                    
                    var neighbours = grid.GetNeighbours(x, y);
                    if (neighbours.Count(position => position == '@') < 4)
                    {
                        reachableRolls.Add((x, y));
                    };
                }
            }
            totalReachableRolls += reachableRolls.Count;

            foreach (var (x, y) in reachableRolls)
            {
                grid[y][x] = '.';
            }
        } 
        while (reachableRolls.Count > 0);

        return totalReachableRolls;
    }
}

public static class Extensions
{
    public static IEnumerable<char> GetNeighbours(this char[][] grid, int x, int y)
    {
        var topX = Math.Max(x - 1, 0);
        var topY = Math.Max(y - 1, 0);
        var bottomX = Math.Min(x + 1, grid[0].Length - 1);
        var bottomY = Math.Min(y + 1, grid.Length - 1);

        for (var j = topY; j <= bottomY; j++)
        {
            for (var i = topX; i <= bottomX; i++)
            {
                if (i == x && j == y) continue;
                yield return grid[j][i];
            }
        }
    }
}
