namespace Basje.AdventOfCode.Y2025.D07;

public class Day07 : Solution<char[][]>
{
    protected override char[][] ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => line.ToCharArray())
            .ToArray();
    }
    
    protected override object SolvePart1(char[][] diagram)
    {
        var numberOfSplits = 0;
        // var beamLocations = new int
        for (var y = 0; y < diagram.Length; y+=2)
        {
            for (var x = 0; x < diagram[y].Length; x++)
            {
                if (y == 0)
                {
                    // Search where tachyon beam enters the manifold
                    if (diagram[y][x] == 'S')
                    {
                        diagram[y + 1][x] = '|';
                        break;
                    }
                    continue;
                }
                
                if (diagram[y][x] == '^' && diagram[y - 1][x] == '|')
                {
                    numberOfSplits++;
                    diagram[y + 1][x - 1] = '|';
                    diagram[y + 1][x + 1] = '|';
                }
                
                if (diagram[y][x] == '.' && diagram[y - 1][x] == '|')
                {
                    diagram[y + 1][x] = '|';
                }
                
            }
        }

        // for (var y = 0; y < diagram.Length; y++)
        // {
        //     for (var x = 0; x < diagram[y].Length; x++)
        //     {
        //         Console.Write(diagram[y][x]);
        //     }
        //     Console.WriteLine();
        // }

        return numberOfSplits;
    }

    protected override object SolvePart2(char[][] diagram)
    {
        return "X";
    }
}
