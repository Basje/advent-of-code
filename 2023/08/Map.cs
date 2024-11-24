namespace Basje.AdventOfCode.Y2023.D08
{
    public record Map
    {
        public required string Instructions { init; get; }
        public required IEnumerable<Node> Nodes { init; get; }
    }
}
