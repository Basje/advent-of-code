namespace Basje.AdventOfCode.Y2023.D02;

public record Set()
{
    public IEnumerable<(string Color, int Count)> Cubes { init; get; } 
}