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

    private readonly record struct Battery(int Location, int Value);

    protected override object SolvePart2(IEnumerable<string> banks)
    {
        const int length = 12;
        var sum = 0L;

        foreach (var bank in banks)
        {
            List<Battery> joltBanks = [];
            var batteries = bank.ToCharArray().Select((c, x) => new Battery(x, c - '0')).ToArray();
            var left = 0;
            
            Battery[] searchSpace, remainingSpace;
            
            do
            {
                searchSpace = batteries[(left)..^(length - joltBanks.Count - 1)];
                remainingSpace = batteries[^(length - joltBanks.Count - 1)..];
                if (remainingSpace.Length + joltBanks.Count == length)
                {
                    joltBanks.AddRange(remainingSpace);
                }
                var max = searchSpace.Max(battery => battery.Value);
                var maxBattery = searchSpace.First(battery => battery.Value == max);
                
                joltBanks.Add(maxBattery);

                left = maxBattery.Location + 1;

            } while (joltBanks.Count < length && joltBanks.Count + remainingSpace.Length >= length);

            sum += joltBanks.Select((battery, index) => battery.Value * (long)Math.Pow(10, length - index - 1)).Sum();
        }
        return sum;
    }
}
