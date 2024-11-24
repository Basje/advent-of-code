namespace Basje.AdventOfCode.Y2023;

public abstract class Solution<T>: ISolution
{
    public object SolvePart1(string input)
    {
        return SolvePart1(ParseInput(input));
    }

    public object SolvePart2(string input)
    {
        return SolvePart2(ParseInput(input));
    }
    
    protected abstract T ParseInput(string input);
    protected abstract object SolvePart1(T parsedInput);
    protected abstract object SolvePart2(T parsedInput);
}