namespace Basje.AdventOfCode.Y2022.D13;

public class Day13 : ISolution
{
    private readonly (string left, string right)[] packets;

    public Day13(string input)
    {
        packets = input
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(pair => pair.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            .Select(pair => (left: pair[0], right: pair[1]))
            .ToArray();
    }

    public object SolvePart1()
    {
        var pairNumber = 1;
        var orderedPairs = new List<int>();

        foreach (var (left, right) in packets)
        {
            if(IsInOrder(left, right, -1, -1))
            {
                orderedPairs.Add(pairNumber);
            }
            pairNumber++;
        }
        return orderedPairs.Sum();
    }

    public object SolvePart2()
    {
        var dividerPackets = new string[] { "[[2]]", "[[6]]" };
        var allPackets = new List<string>();

        allPackets.AddRange(dividerPackets);

        foreach (var (left, right) in packets)
        {
            allPackets.Add(left);
            allPackets.Add(right);
        }

        var sorted = allPackets.Order(new PacketComparer());
        var dividerPacketLocations = new List<int>();
        var searchLocation = 1;

        foreach(var packet in sorted)
        {
            if (dividerPackets.Contains(packet))
            {
                dividerPacketLocations.Add(searchLocation);
            }
            searchLocation++;
        }

        return dividerPacketLocations.Aggregate((left, right) => left * right); ;
    }

    // Recursive function to walk through both packets simultaneously
    public static bool IsInOrder(string left, string right, int lNumber, int rNumber)
    {
        const int NONE = 1;

        if (left.Length == 0 || right.Length == 0) return true;

        return (left: left[0], right: right[0]) switch
        {
            // Exit: one list or both lists have run out of items
            (']', '[') or (']', ',') => lNumber == rNumber || lNumber < rNumber,
            ('[', ']') or (',', ']') => lNumber != rNumber && lNumber < rNumber,
            (']', ']') or (',', ',') when lNumber != rNumber => lNumber < rNumber,

            // Continue: so far still the same
            (']', ']') or (',', ',') or ('[', '[') when lNumber == rNumber 
                => IsInOrder(left.Next(), right.Next(), NONE, NONE),

            // Continue: parse number that is bigger than 9
            (>= '0' and <= '9', ',' or ']') token => IsInOrder(left.Next(), right, lNumber.Add(token.left), rNumber),
            (',' or ']', >= '0' and <= '9') token => IsInOrder(left, right.Next(), lNumber, rNumber.Add(token.right)),
            
            // Continue: mixed type, make list of the number
            (>= '0' and <= '9', '[') token => IsInOrder(left.NumberToList(), right, NONE, NONE),
            ('[', >= '0' and <= '9') token => IsInOrder(left, right.NumberToList(), NONE, NONE),
            
            // Continue: digits, track numbers and keep parsing 
            (>= '0' and <= '9', >= '0' and <= '9') token
                => IsInOrder(left.Next(), right.Next(), lNumber.Add(token.left), rNumber.Add(token.right)),

            // Are we done debugging yet?
            (_, _) token => throw new Exception($"Unexpected combination: ( {token.left} , {token.right} )"),
        };
    }
}

public class PacketComparer : StringComparer
{
    public override int Compare(string? left, string? right)
    {
        return (left, right) switch
        {
            (null, null) => 0,
            (null, _) => -1,
            (_, null) => 1,
            (_, _) => Day13.IsInOrder(left, right, -1, -1) ? -1 : 1,
        };
    }

    public override bool Equals(string? left, string? right) => Compare(left, right) == 0;

    public override int GetHashCode(string obj) => obj.GetHashCode();
}

public static class Extensions
{
    public static string Next(this string packet) => packet[1..];

    public static int Add(this int number, char next) => number switch
    {
        < 0 => next - '0',
        _ => number * 10 + (next - '0'),
    };

    public static string NumberToList(this string packet)
    {
        var insertAt = packet.IndexOfAny(new char[] { ',', '[', ']' });

        return insertAt switch
        {
            -1 => '[' + packet + ']',
            _ => "[" + packet[..insertAt] + "]" + packet[insertAt..],
        };
    }
}
