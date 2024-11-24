namespace Basje.AdventOfCode.Y2023.D03;

public record Token(char Value, Coordinates Coordinates)
{
    public bool IsNumber => Value is >= '0' and <= '9';

    public bool IsSymbol => !IsNumber && !IsPeriod && !IsEndOfLine;

    public bool IsPeriod => Value == '.';

    public bool IsEndOfLine => Value == '\n';

    public int Digit => int.Parse(Value.ToString());
}