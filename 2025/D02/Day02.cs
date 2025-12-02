namespace Basje.AdventOfCode.Y2025.D02;

public class Day02 : Solution<IEnumerable<(long Start, long End)>>
{
    protected override IEnumerable<(long Start, long End)> ParseInput(string input)
    {
        return input
            .Split(',')
            .Select(line => line.Split('-'))
            .Select(line => (Start: long.Parse(line[0]), End: long.Parse(line[1])));
    }
    
    protected override object SolvePart1(IEnumerable<(long Start, long End)> ids)
    {
        long sum = 0;

        foreach (var (start, end) in ids)
        {
            for (var i = start; i <= end; i++)
            {
                var numberLength = i.ToString().Length;
                var leftPart = i.ToString()[..(numberLength / 2)];
                var rightPart = i.ToString()[(numberLength / 2)..];

                if (leftPart == rightPart)
                {
                    sum += i;
                }
            }
        }
        
        return sum;
    }

    protected override object SolvePart2(IEnumerable<(long Start, long End)> ids)
    {
        long sum = 0;

        foreach (var (start, end) in ids)
        {
            for (var i = start; i <= end; i++)
            {
                var id = i.ToString();
                var halveNumberLength = i.ToString().Length / 2;

                for (var size = halveNumberLength; size > 0; size--)
                {
                    var chunks = id.Chunk(size).Select(chunk => new string(chunk));
                    if (chunks.Distinct().Count() == 1)
                    {
                        sum += i;
                        break;
                    }
                }
            }
        }
        
        return sum;
    }
}
