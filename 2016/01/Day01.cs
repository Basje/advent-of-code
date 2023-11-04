namespace Basje.AdventOfCode.Y2016.D01;

public class Day01 : Solution<IEnumerable<(char direction, int distance)>>
{
    protected override IEnumerable<(char direction, int distance)> ParseInput(string input)
    {
        return input
            // Separate the different commands    
            .Split(", ")
            // Convert commands to more workable format
            .Select(command => (direction: command[0], distance: int.Parse(command[1..].ToString())));
    }
    
    protected override object SolvePart1(IEnumerable<(char direction, int distance)> input)
    {
        var currentPosition = (x: 0, y: 0);
        var direction = 'N';
        
        foreach (var command in input)
        {
            direction = (direction, command.direction) switch
            {
                ('N', 'L') => 'W',
                ('N', 'R') => 'E',
                ('E', 'L') => 'N',
                ('E', 'R') => 'S',
                ('S', 'L') => 'E',
                ('S', 'R') => 'W',
                ('W', 'L') => 'S',
                ('W', 'R') => 'N',
            };
            
            currentPosition = direction switch
            {
                'N' => (currentPosition.x, currentPosition.y + command.distance),
                'E' => (currentPosition.x + command.distance, currentPosition.y),
                'S' => (currentPosition.x, currentPosition.y - command.distance),
                'W' => (currentPosition.x - command.distance, currentPosition.y),
            };
        }
        
        return Math.Abs(currentPosition.x) + Math.Abs(currentPosition.y);
    }

    protected override object SolvePart2(IEnumerable<(char direction, int distance)> input)
    {
        return -1;
    }
}
