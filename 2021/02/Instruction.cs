namespace Basje.AdventOfCode.Y2021.D02
{
    public record Instruction
    {
        public string Dimension { get; init; }
        public int Distance { get; init; }

        public Instruction(string dimension, int distance)
        {
            Dimension = dimension;
            Distance = distance;
        }
    }
}
