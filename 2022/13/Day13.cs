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
            if(IsInOrder(left, right, 0, -1, -1))
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
    public static bool IsInOrder(string left, string right, int level, int lNumber, int rNumber)
    {
        const int NONE = 1;

        if (level == 0 && (left.Length == 0 || right.Length == 0)) return true;

        return (left: left[0], right: right[0]) switch
        {
            // Exit: left has run out of items
            (']', '[') or (']', ',') => lNumber == rNumber || lNumber < rNumber,
            // Exit: right has run out of items
            ('[', ']') or (',', ']') => lNumber != rNumber && lNumber < rNumber,
            // Exit: compare different items in packets
            (']', ']') or (',', ',') when lNumber != rNumber => lNumber < rNumber,

            // Continue: so far still the same, go up a level
            (']', ']') when lNumber == rNumber 
                => IsInOrder(left.Next(), right.Next(), --level, NONE, NONE),
            // Continue: so far still the same, stay in level
            (',', ',') when lNumber == rNumber 
                => IsInOrder(left.Next(), right.Next(), level, NONE, NONE),
            // Continue: new list in both packets, go down a level
            ('[', '[') 
                => IsInOrder(left.Next(), right.Next(), ++level, NONE, NONE),
            // Continue: left is next digit of current number, right is ready for next number
            (>= '0' and <= '9', ',') token 
                => IsInOrder(left.Next(), right, level, lNumber.Add(token.left), rNumber),
            // Continue: left is next digit of current number, right is end of list
            (>= '0' and <= '9', ']') token 
                => rNumber >= 0 && IsInOrder(left.Next(), right, level, lNumber.Add(token.left), rNumber),
            // Continue: left is ready for next number, right is next digit of current number
            (',', >= '0' and <= '9') token 
                => IsInOrder(left, right.Next(), level, lNumber, rNumber.Add(token.right)),
            // Continue: left is end of list, right is next digit of current number
            (']', >= '0' and <= '9') token 
                => lNumber == NONE || IsInOrder(left, right.Next(), level, lNumber, rNumber.Add(token.right)),
            // Continue: mixed types, right is plain number while left is new list
            ('[', >= '0' and <= '9') token 
                => IsInOrder(left, right.NumberToList(), level, NONE, NONE),
            // Continue: mixed types, left is plain number while right is new list
            (>= '0' and <= '9', '[') token 
                => IsInOrder(left.NumberToList(), right, level, NONE, NONE),
            // Continue: digits, track numbers and keep parsing 
            ( >= '0' and <= '9', >= '0' and <= '9') token
                => IsInOrder(left.Next(), right.Next(), level, lNumber.Add(token.left), rNumber.Add(token.right)),

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
            (_, _) => Day13.IsInOrder(left, right, 0, -1, -1) ? -1 : 1,
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
