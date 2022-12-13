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

        foreach (var pair in packets)
        {
            if(IsInOrder(pair.left, pair.right, 0, 0, 0))
            {
                orderedPairs.Add(pairNumber);
            }
            pairNumber++;
        }
        return orderedPairs.Sum();
    }

    public object SolvePart2()
    {
        var allPackets = new List<string>() { "[[2]]", "[[6]]" };

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
            if (new string[] {"[[2]]", "[[6]]"}.Contains(packet))
            {
                dividerPacketLocations.Add(searchLocation);
            }
            searchLocation++;
        }

        var decoderKey = 1;

        foreach(var location in  dividerPacketLocations)
        {
            decoderKey *= location;
        }

        return decoderKey;
    }

    // Recursive function to walk through both packets simultaneously
    public static bool IsInOrder(string left, string right, int level, int lNumber, int rNumber)
    {
        if (level == 0 && (left.Length == 0 || right.Length == 0)) return true;

        return (left: left[0], right: right[0]) switch
        {
            // Exit case: left has run out of items
            (']', '[') or (']', ',') => lNumber == rNumber || lNumber < rNumber,

            // Exit case: right has run out of items
            ('[', ']') or (',', ']') => lNumber != rNumber && lNumber < rNumber,

            // Possible exit case: compare last items in packets
            (']', ']')
                => lNumber == rNumber
                    ? IsInOrder(left.Next(), right.Next(), --level, -1, -1)
                    : lNumber < rNumber,

            // Possible exit case: compare items in packets
            (',', ',')
                => lNumber == rNumber
                    ? IsInOrder(left.Next(), right.Next(), level, -1, -1)
                    : lNumber < rNumber,

            // New list in both packets
            ('[', '[')
                => IsInOrder(left.Next(), right.Next(), ++level, -1, -1),

            // Left is next digit of current number, right is ready for next number
            (_, ',') token when token.left.IsDigit()
                => IsInOrder(left.Next(), right, level, lNumber.Add(token.left), rNumber),

            // Left is next digit of current number, right is end of list
            (_, ']') token when token.left.IsDigit()
                => rNumber < 0 ? false : IsInOrder(left.Next(), right, level, lNumber.Add(token.left), rNumber),

            // Left is ready for next number, right is next digit of current number
            (',', _) token when token.right.IsDigit()
                => IsInOrder(left, right.Next(), level, lNumber, rNumber.Add(token.right)),

            // Left is end of list, right is next digit of current number
            (']', _) token when token.right.IsDigit()
                => lNumber < 0 ? true : IsInOrder(left, right.Next(), level, lNumber, rNumber.Add(token.right)),

            // Mixed types, right is plain number while left is new list
            ('[', _) token when token.right.IsDigit()
                => IsInOrder(left, right.NumberToList(), level, -1, -1),

            // Mixed types, left is plain number while right is new list
            (_, '[') token when token.left.IsDigit()
                => IsInOrder(left.NumberToList(), right, level, -1, -1),

            // Digits, track numbers and keep parsing
            (_, _) token when token.left.IsDigit() && token.right.IsDigit()
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
        if (left is null && right is null) return 0;
        if (left is null) return -1;
        if (right is null) return 1;

        return Day13.IsInOrder(left, right, 0, -1, -1) ? -1 : 1;
    }

    public override bool Equals(string? left, string? right)
    {
        return Compare(left, right) == 0;
    }

    public override int GetHashCode(string obj)
    {
        return obj.GetHashCode();
    }
}

public static class Extensions
{
    public static bool IsDigit(this char character)
    {
        return character >= '0' && character <= '9';
    }

    public static string Next(this string packet)
    {
        return packet[1..];
    }

    public static int Add(this int number, char next)
    {
        return number < 0 ? next - '0' : number * 10 + (next - '0');
    }

    public static string NumberToList(this string packet)
    {
        var nextComma = packet.IndexOf(',');
        var nextOpeningBracket = packet.IndexOf("[");
        var nextClosingBracket = packet.IndexOf("]");

        var indices = new int[] { 
            nextComma < 0 ? int.MaxValue : nextComma,
            nextOpeningBracket < 0 ? int.MaxValue : nextOpeningBracket,
            nextClosingBracket < 0 ? int.MaxValue : nextClosingBracket,
        };

        var newClosingBracketLocation = indices.Min();

        return newClosingBracketLocation switch
        {
            int.MaxValue => '[' + packet + ']',
            _ => "[" + packet[..newClosingBracketLocation] + "]" + packet[newClosingBracketLocation..],
        };
    }
}
