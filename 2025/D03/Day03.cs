namespace Basje.AdventOfCode.Y2025.D03;

public class Day03 : Solution<IEnumerable<string>>
{
    protected override IEnumerable<string> ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines();
    }
    
    protected override object SolvePart1(IEnumerable<string> banks)
    {
        var sum = 0;

        foreach (var bank in banks)
        {
            var x = bank[..^1].ToCharArray().Select(c => c - '0').Max();
            var firstDigitLoc = bank.IndexOf(x.ToString());
            var rest = bank[(firstDigitLoc + 1)..] + bank[^1];
            var y = rest.ToCharArray().Select(c => c - '0').Max();
            sum += x * 10 + y;
        }
        return sum;
    }

    protected override object SolvePart2(IEnumerable<string> banks)
    {
        return 'X';
    }
}
