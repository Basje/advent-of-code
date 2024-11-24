namespace Basje.AdventOfCode.Y2023.Input;

public static class InputParsers
{
    public static IEnumerable<string> PerLine(this string input)
    {
        // Take Windows-style line-endings into consideration
        return input.Replace("\r","").Split("\n");
    }

    public static IEnumerable<string> PerBlock(this string input)
    {
        // Take Windows-style line-endings into consideration
        return input.Replace("\r","").Split("\n\n");
    }

    public static IEnumerable<string> IgnoreEmptyLines(this IEnumerable<string> input)
    {
        return input.Where(line => !line.Equals(string.Empty));
    }
}