namespace Basje.AdventOfCode.Y2025.D01;

public class Day01 : Solution<IEnumerable<(char Direction, int Distance)>>
{
    protected override IEnumerable<(char Direction, int Distance)> ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => (Direction: line[0], Distance: int.Parse(line[1..])));
    }
    
    protected override object SolvePart1(IEnumerable<(char Direction, int Distance)> sequence)
    {
        var currentValue = 50;
        var timesAtZero = 0;

        foreach (var instruction in sequence)
        {
            currentValue = instruction.Direction switch
            {
                'L' => (currentValue - instruction.Distance + 100) % 100,
                'R' => (currentValue + instruction.Distance) % 100,
                _ => throw new Exception($"Invalid direction: '{instruction.Direction}")
            };

            if (currentValue == 0)
            {
                timesAtZero++;
            }
        }
        
        return timesAtZero;
    }

    protected override object SolvePart2(IEnumerable<(char Direction, int Distance)> sequence)
    {
        var previousValue = 50;
        var currentValue = 50;
        var timesAtZero = 0;

        foreach (var instruction in sequence)
        {
            previousValue = currentValue;
            currentValue = instruction.Direction switch
            {
                // Apparently C# % is not a true modulo, but a remainder operation
                'L' => (((currentValue - instruction.Distance) % 100) + 100) % 100,
                'R' => (currentValue + instruction.Distance) % 100,
                _ => throw new Exception($"Invalid direction: '{instruction.Direction}")
            };

            var fullRotations = instruction.Distance / 100;
            
            timesAtZero += fullRotations;

            if (currentValue == 0)
            {
                timesAtZero++;
            }
            else if (previousValue != 0)
            {
                timesAtZero += instruction.Direction switch
                {
                    'L' => currentValue > previousValue ? 1 : 0,
                    'R' => currentValue < previousValue ? 1 : 0,
                    _ => throw new Exception($"Invalid direction: '{instruction.Direction}'")
                };
            }
        }
        
        return timesAtZero;
    }
}
