using System.Diagnostics;

namespace Basje.AdventOfCode.Y2023.D03;

[DebuggerDisplay("{value} ({left.X},{left.Y}),({right.X},{right.Y})")]
public class Number
{
    private readonly Coordinates left;
    private readonly Coordinates right;
    private readonly int value;
    private bool isPartNumber = false;
    
    public Number(int value, Coordinates left, Coordinates right)
    {
        this.value = value;
        this.left = left;
        this.right = right;
    }

    public bool IsPartNumber => isPartNumber;
    public int Value => value;

    public bool AdjacentAreaIncludes(Coordinates coordinates)
    {
        return coordinates.X >= left.X - 1
               && coordinates.X <= right.X + 1
               && coordinates.Y >= Math.Min(left.Y, right.Y) - 1
               && coordinates.Y <= Math.Max(left.Y, right.Y) + 1;
    }

    public void MarkAsPartNumber()
    {
        isPartNumber = true;
    }
}