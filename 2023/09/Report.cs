namespace Basje.AdventOfCode.Y2023.D09
{
    public record Report
    {
        public required IEnumerable<IList<int>> Histories { init; get; }
    }
}
