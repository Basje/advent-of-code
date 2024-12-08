namespace Basje.AdventOfCode.Y2024.D08;

public class Day08 : Solution<IGrouping<char,((int X, int Y) Coordinates, char Character)>[]>
{
    protected override IGrouping<char,((int X, int Y) Coordinates, char Character)>[] ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .SelectMany((line, y) => line.Select((character, x) => ((X: x, Y: y), character)))
            .GroupBy(cell => cell.character)
            .ToArray();
    }

    protected override object SolvePart1(IGrouping<char,((int X, int Y) Coordinates, char Character)>[] groups)
    {
        var (maxX, maxY) = groups
            .Single(group => group.Key == '.')
            .Max(cell => cell.Coordinates);

        List<(int X, int Y)> antinodes = [];

        foreach (var group in groups)
        {
            if (group.Key == '.') continue;

            var items = group.ToArray();

            for (var i = 0; i < items.Length; i++)
            {
                for (var j = i + 1; j < items.Length; j++)
                {
                    var left = items[i].Coordinates;
                    var right = items[j].Coordinates;

                    var diffX = right.X - left.X;
                    var diffY = right.Y - left.Y;

                    var firstAntinode = (X: right.X + diffX, Y: right.Y + diffY);
                    var secondAntinode = (X: left.X - diffX, Y: left.Y - diffY);

                    if (firstAntinode.X >= 0 && firstAntinode.X <= maxX && firstAntinode.Y >= 0 && firstAntinode.Y <= maxY)
                    {
                        antinodes.Add(firstAntinode);
                    }
                    
                    if (secondAntinode.X >= 0 && secondAntinode.X <= maxX && secondAntinode.Y >= 0 && secondAntinode.Y <= maxY)
                    {
                        antinodes.Add(secondAntinode);
                    }
                }
            }
        }
        
        return antinodes.Distinct().Count();
    }

    protected override object SolvePart2(IGrouping<char,((int X, int Y) Coordinates, char Character)>[] groups)
    {
        var (maxX, maxY) = groups
            .Single(group => group.Key == '.')
            .Max(cell => cell.Coordinates);

        List<(int X, int Y)> antinodes = [];

        var antennas = groups
            .Where(group => group.Key != '.')
            .SelectMany(group => group.ToArray())
            .Select(item => item.Coordinates);

        foreach (var group in groups)
        {
            if (group.Key == '.') continue;

            var items = group.ToArray();

            for (var i = 0; i < items.Length; i++)
            {
                for (var j = i + 1; j < items.Length; j++)
                {
                    var left = items[i].Coordinates;
                    var right = items[j].Coordinates;

                    var diffX = right.X - left.X;
                    var diffY = right.Y - left.Y;

                    var firstAntinode = (X: right.X + diffX, Y: right.Y + diffY);
                    var secondAntinode = (X: left.X - diffX, Y: left.Y - diffY);

                    while (firstAntinode.X >= 0 && firstAntinode.X <= maxX && firstAntinode.Y >= 0 && firstAntinode.Y <= maxY)
                    {
                        antinodes.Add(firstAntinode);
                        
                        firstAntinode = (X: firstAntinode.X + diffX, Y: firstAntinode.Y + diffY);
                    }
                    
                    while (secondAntinode.X >= 0 && secondAntinode.X <= maxX && secondAntinode.Y >= 0 && secondAntinode.Y <= maxY)
                    {
                        antinodes.Add(secondAntinode);
                        
                        secondAntinode = (X: secondAntinode.X - diffX, Y: secondAntinode.Y - diffY);
                    }
                }
            }
        }
        
        antinodes.AddRange(antennas);

        return antinodes.Distinct().Count();
    }
}

internal static class Day08Extensions
{

}
