namespace Basje.AdventOfCode.Y2023.D02;

public record Game()
{
    public int Id { init; get; }
    public IEnumerable<Set> Sets { init; get; }
}