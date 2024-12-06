namespace Basje.AdventOfCode.Y2024.D06;

public class Day06 : Solution<Dictionary<(int X, int Y), char>>
{
    protected override Dictionary<(int X, int Y), char> ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => line.ToArray())
            .SelectMany((line, y) => line.Select((position, x) => (X: x, Y: y, Value: position)))
            .ToDictionary(position => (position.X, position.Y), position => position.Value);
    }

    protected override object SolvePart1(Dictionary<(int X, int Y), char> map)
    {
        var guard = map.Single(position => position.Value == '^').Key;
        var next = guard;
        var direction = 'N';
        var onMap = true;

        while (onMap)
        {
            map[guard] = 'X';
            next = (guard, direction) switch
            {
                (_, 'N') => (guard.X, guard.Y - 1),
                (_, 'E') => (guard.X + 1, guard.Y),
                (_, 'S') => (guard.X, guard.Y + 1),
                (_, 'W') => (guard.X - 1, guard.Y),
                _ => next
            };
            onMap = map.ContainsKey(next);
            
            if(!onMap) continue;

            var isObstruction = map[next] == '#';

            direction = (direction, isObstruction) switch
            {
                (_, false) => direction,
                ('N', true) => 'E',
                ('E', true) => 'S',
                ('S', true) => 'W',
                ('W', true) => 'N',
                _ => direction
            };
            
            if(isObstruction) continue;

            guard = next;
        }

        return map.Count(pair => pair.Value == 'X');
    }

    protected override object SolvePart2(Dictionary<(int X, int Y), char> map)
    {
        // Not working :( 
        // Need to think about this...
        
        var guard = map.Single(position => position.Value == '^').Key;
        var next = guard;
        var direction = 'N';
        var onMap = true;
        var loopCount = 0;

        while (onMap)
        {
            map[guard] = (map[guard], direction) switch
            {
                ('.', 'N') or ('.', 'S') => '|',
                ('.', 'E') or ('.', 'W') => '-',
                ('|', 'E') or ('|','W') => '+',
                ('-', 'N') or ('-', 'S') => '+',
                ('+', _) => '+',
                ('^', _) => '|',
            };
            next = (guard, direction) switch
            {
                (_, 'N') => (guard.X, guard.Y - 1),
                (_, 'E') => (guard.X + 1, guard.Y),
                (_, 'S') => (guard.X, guard.Y + 1),
                (_, 'W') => (guard.X - 1, guard.Y),
                _ => next
            };
            onMap = map.ContainsKey(next);
            
            if(!onMap) continue;

            var isObstruction = map[next] == '#';

            if (!isObstruction)
            {
                var right = (guard, direction) switch
                {
                    (_, 'N') => (guard.X, guard.Y - 1),
                    (_, 'E') => (guard.X + 1, guard.Y),
                    (_, 'S') => (guard.X, guard.Y + 1),
                    (_, 'W') => (guard.X - 1, guard.Y),
                };

                if (map.ContainsKey(right))
                {
                    var possibleLoop = (direction, map[right]) switch
                    {
                        ('N', '-') or ('S', '-') => true,
                        ('E', '|') or ('W', '|') => true,
                        _ => false
                    };
                }
            }

            direction = (direction, isObstruction) switch
            {
                (_, false) => direction,
                ('N', true) => 'E',
                ('E', true) => 'S',
                ('S', true) => 'W',
                ('W', true) => 'N',
                _ => direction
            };
            
            if(isObstruction) continue;

            guard = next;
        }

        return map.Count(pair => pair.Value == 'X');
    }
}

internal static class Day06Extensions
{
}
