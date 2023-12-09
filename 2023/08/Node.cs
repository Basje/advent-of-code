namespace Basje.AdventOfCode.Y2023.D08
{
    public record Node
    {
        public required string Name { init; get; }
        public required string Left { init; get; }
        public required string Right { init; get; }
    }
}
