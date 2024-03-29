﻿using System.Diagnostics;

namespace Basje.AdventOfCode.Y2022.D09;

public class Day09 : ISolution
{
    private readonly IEnumerable<Motion> motions;

    public Day09(string input)
    {
        motions = input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(motion => motion.Split(' '))
            .Select(motion => new Motion { Direction = char.Parse(motion[0]), Steps = int.Parse(motion[1]) });
    }

    public object SolvePart1()
    {
        var tail = Position.Start;
        var visited = new List<Position> { tail };

        foreach (var head in Position.Start.Move(motions))
        {
            tail = tail.Follow(head);
            visited.Add(tail);
        }

        return visited.Distinct().Count();
    }

    public object SolvePart2()
    {
        var rope = new Position[10];
        var visited = new List<Position>();

        foreach (var head in Position.Start.Move(motions))
        {
            rope[0] = head;
            for (var i = 1; i < rope.Length; i++)
            {
                rope[i] = rope[i].Follow(rope[i-1]);
            }
            visited.Add(rope[9]);
        }

        return visited.Distinct().Count();
    }
}

[DebuggerDisplay("( {X} , {Y} )")]
public struct Position
{
    public required int X { get; init; }
    public required int Y { get; init; }
    public static Position Start => new() { X = 0, Y = 0 };
}

public record Motion
{
    public required char Direction { get; init; }
    public required int Steps { get; init; }
}

public static class Extentions
{
    public static IEnumerable<Position> Move(this Position start, IEnumerable<Motion> motions)
    {
        var lastKnowPosition = start;
        foreach(var motion in motions)
        {
            foreach(var position in lastKnowPosition.Move(motion))
            {
                lastKnowPosition = position;
                yield return position;
            }
        }
    }

    public static IEnumerable<Position> Move(this Position start, Motion motion)
    {
        for (int step = 1; step <= motion.Steps; step++) {
            yield return motion.Direction switch
            {
                'U' => new Position { X = start.X, Y = start.Y + step },
                'D' => new Position { X = start.X, Y = start.Y - step },
                'L' => new Position { Y = start.Y, X = start.X - step },
                'R' => new Position { Y = start.Y, X = start.X + step },
                _ => throw new Exception(),
            };
        }
    }

    public static Position Follow(this Position tail, Position head)
    {
        return tail.DistanceTo(head) switch
        {
            // Touching, so just stay at the current position
            { deltaX: 1 or 0 or -1, deltaY: 1 or 0 or -1 } => tail,
            // Vertical movement
            { deltaX: 0, deltaY:  2 } => new Position { X = tail.X, Y = tail.Y + 1 },
            { deltaX: 0, deltaY: -2 } => new Position { X = tail.X, Y = tail.Y - 1 },
            // Horizontal movement
            { deltaY: 0, deltaX:  2 } => new Position { X = tail.X + 1, Y = tail.Y },
            { deltaY: 0, deltaX: -2 } => new Position { X = tail.X - 1, Y = tail.Y },
            // Diagonal movement
            { deltaX: > 0, deltaY: > 0 } => new Position { X = tail.X + 1, Y = tail.Y + 1 },
            { deltaX: > 0, deltaY: < 0 } => new Position { X = tail.X + 1, Y = tail.Y - 1 },
            { deltaX: < 0, deltaY: > 0 } => new Position { X = tail.X - 1, Y = tail.Y + 1 },
            { deltaX: < 0, deltaY: < 0 } => new Position { X = tail.X - 1, Y = tail.Y - 1 },
            // Other distances should not be possible
            _ => throw new Exception(),
        };
    }

    public static (int deltaX, int deltaY) DistanceTo(this Position tail, Position head)
    {
        return (head.X - tail.X, head.Y - tail.Y);
    }
}
