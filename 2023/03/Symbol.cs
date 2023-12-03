namespace Basje.AdventOfCode.Y2023.D03;

public record Symbol(char Value, Coordinates Coordinates)
{
    public bool IsGear { get; private set; } = false;

    public void MarkAsGear()
    {
        IsGear = true;
    }
}