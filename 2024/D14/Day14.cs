namespace Basje.AdventOfCode.Y2024.D14;

public class Day14 : Solution<((int X, int Y) Position, (int X, int Y) Velocity)[]>
{
    protected override ((int X, int Y) Position, (int X, int Y) Velocity)[] ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => 
                line.Replace("p=", "")
                    .Split(" v=")
                    .IgnoreEmptyLines()
                    .ToArray()
                )
            .Select(line => (
                Position: line[0].Split(",").Select(int.Parse).ToArray(),
                Velocity: line[1].Split(",").Select(int.Parse).ToArray())
            )
            .Select(line => (
                Position: (X: line.Position[0], Y: line.Position[1]),
                Velocity: (X: line.Velocity[0], Y: line.Velocity[1]))
            )
            .ToArray();
    }

    protected override object SolvePart1(((int X, int Y) Position, (int X, int Y) Velocity)[] list)
    {
        var height = list.Select(robot => robot.Position.Y).Max() + 1;
        var width = list.Select(robot => robot.Position.X).Max() + 1;

        List<(int X, int Y)> robots = [];

        foreach (var robot in list)
        {
            var newPosition = (
                X: robot.Position.X + 100 * robot.Velocity.X,
                Y: robot.Position.Y + 100 * robot.Velocity.Y);

            newPosition = (X: newPosition.X.Modulo(width), Y: newPosition.Y.Modulo(height));
            
            robots.Add(newPosition);
        }

        robots.RemoveAll(robot => robot.X == width / 2 || robot.Y == height / 2);

        var nw = robots.Count(robot => robot.X <= width / 2 && robot.Y <= height / 2);
        var ne = robots.Count(robot => robot.X > width / 2 && robot.Y <= height / 2);
        var sw = robots.Count(robot => robot.X <= width / 2 && robot.Y > height / 2);
        var se = robots.Count(robot => robot.X > width / 2 && robot.Y > height / 2);

        return nw * ne * sw * se;
    }

    protected override object SolvePart2(((int X, int Y) Position, (int X, int Y) Velocity)[] list)
    {
        var height = list.Select(robot => robot.Position.Y).Max() + 1;
        var width = list.Select(robot => robot.Position.X).Max() + 1;

        var treeFound = false;
        var i = 1;
        // var key = '.';
        
        while (!treeFound)
        {
            
            List<(int X, int Y)> robots = [];
            
            foreach (var robot in list)
            {
                var newPosition = (
                    X: robot.Position.X + i * robot.Velocity.X,
                    Y: robot.Position.Y + i * robot.Velocity.Y);

                newPosition = (X: newPosition.X.Modulo(width), Y: newPosition.Y.Modulo(height));

                robots.Add(newPosition);
            }
            
            // First wrote a visualiser. Then looked through the output and
            // noticed that sometimes the robots seemed to cluster. Based on 
            // clustering I played with values of number of robots on the same
            // line. I visually found tree, after which I updated the search
            // criteria.
            treeFound = robots
                .GroupBy(robot => robot.Y)
                .Count(line => line.Count() >= 31) == 2
                && robots
                    .GroupBy(robot => robot.X)
                    .Count(column => column.Count() >= 33) == 2;
            
            // if (treeFound)
            // {
            //     Console.WriteLine($"i: {i}");
            //     robots.Print(width, height);
            //     key = Console.ReadKey().KeyChar;
            // }

            i++;
        }
        return i;
    }
}

internal static class Day14Extensions
{
    // Apparently the % operator in C# is not an actual modulo, but the remainder.
    // So we need to make a correct modulo that works with negative numbers too.
    // Source: https://stackoverflow.com/a/6400477
    internal static int Modulo(this int a, double b)
    {
        return (int)Math.Round(a - b * Math.Floor(a / b));
    }

    internal static void Print(this List<(int X, int Y)> robots, int width, int height)
    {
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var character = '.';
                if (robots.Contains((X: x, Y: y)))
                {
                    character = 'X';
                }
                Console.Write(character);
                if (x == width - 1)
                {
                    Console.WriteLine();
                }
            }

            if (y == height - 1)
            {
                Console.WriteLine();
            }
        }
    }
}
