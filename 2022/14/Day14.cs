namespace Basje.AdventOfCode.Y2022.D14;

public class Day14 : ISolution
{
    private readonly IEnumerable<IEnumerable<(int x, int y)>> scan;
    public Day14(string input)
    {
        scan = input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(path => path.Split(" -> "))
            .Select(path => path.Select(line => line.Split(',').Select(int.Parse)))
            .Select(path => path.Select(line => (x: line.First(), y: line.Last())));
    }

    public object SolvePart1()
    {
        var grid = CreateGrid(scan);
        var lowestPoint = scan.Max(path => path.Max(line => line.y));
        var mostRight = scan.Max(path => path.Max(line => line.x));
        var mostLeft = scan.Min(path => path.Min(line => line.x));
        var source = (x: 500, y: 0);
        var path = new Stack<(int x, int y)>();
        var next = source;

        path.Push(source);

        while (path.Any() && next.y < lowestPoint)
        {
            next = path.Peek();
            var x = next.x;
            var y = next.y + 1;

            if (grid[x,y] == Element.Air)
            {
                path.Push((x, y));
            }
            else if (grid[x - 1, y] == Element.Air)
            {
                path.Push((x - 1, y));
            }
            else if (grid[x + 1, y] == Element.Air)
            {
                path.Push((x + 1, y));
            }
            else
            {
                grid[next.x, next.y] = Element.Sand;
                path.Pop();
            }
        }
        return grid.All().Count(element => element == Element.Sand);
    }

    public object SolvePart2()
    {
        var grid = CreateGrid(scan);
        var lowestPoint = scan.Max(path => path.Max(line => line.y));
        var mostRight = scan.Max(path => path.Max(line => line.x));
        var mostLeft = scan.Min(path => path.Min(line => line.x));
        var source = (x: 500, y: 0);
        var path = new Stack<(int x, int y)>();
        var next = source;

        path.Push(source);

        while (path.Any() && grid[500, 0] != Element.Sand)
        {
            next = path.Peek();
            var x = next.x;
            var y = next.y + 1;
            var isFloor = y == lowestPoint + 2;

            if (grid[x, y] == Element.Air && !isFloor)
            {
                path.Push((x, y));
            }
            else if (grid[x - 1, y] == Element.Air && !isFloor)
            {
                path.Push((x - 1, y));
            }
            else if (grid[x + 1, y] == Element.Air && !isFloor)
            {
                path.Push((x + 1, y));
            }
            else
            {
                grid[next.x, next.y] = Element.Sand;
                path.Pop();
            }
        }
        return grid.All().Count(element => element == Element.Sand);
    }

    public static Element[,] CreateGrid(IEnumerable<IEnumerable<(int x, int y)>> scan)
    {
        var grid = new Element[1001, 501];

        foreach (var path in scan)
        {
            path.Aggregate((start, end) =>
            {
                var xx = Enumerable.Range(Math.Min(start.x, end.x), Math.Abs(start.x - end.x) + 1);
                var yy = Enumerable.Range(Math.Min(start.y, end.y), Math.Abs(start.y - end.y) + 1);

                foreach (var x in xx)
                {
                    foreach (var y in yy)
                    {
                        grid[x, y] = Element.Rock;
                    }
                }
                return end;
            });
        }

        return grid;
    }
}

public enum Element
{
    Air = 0,
    Rock = 1,
    Sand = 2,
}

public static class Extensions
{
    public static IEnumerable<Element> All(this Element[,] grid)
    {
        foreach (var element in grid)
        {
            yield return element;
        }
    }

    public static void Paint(this Element[,] grid, (int x, int y) topLeft, (int x, int y) bottomRight)
    {
        for (var y = topLeft.y;  y <= bottomRight.y; y++) { 
            for (var x = topLeft.x; x <= bottomRight.x; x++)
            {
                Console.Write(grid[x, y] switch { 
                    Element.Air => '.',
                    Element.Rock => '#',
                    Element.Sand => 'o',
                });
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
