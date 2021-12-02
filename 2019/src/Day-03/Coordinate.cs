using System;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode_2019.Day_03
{
    sealed public class Coordinate : IEquatable<Coordinate>
    {
        internal Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal int X { get; }
        internal int Y { get; }

        public int CalculateManhattanDistanceTo(Coordinate other)
        {
            return Math.Abs(other.X - X) + Math.Abs(other.Y - Y);
        }

        public bool Equals([AllowNull] Coordinate other)
        {
            if (other is null) return false;

            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
