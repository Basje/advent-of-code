namespace Basje.AdventOfCode.Y2016.D01;

public class Day01 : Solution<IEnumerable<(char turn, int distance)>>
{
    private const char NORTH = 'N';
    private const char EAST = 'E';
    private const char SOUTH = 'S';
    private const char WEST = 'W';

    private const char LEFT = 'L';
    private const char RIGHT = 'R';
    
    protected override IEnumerable<(char turn, int distance)> ParseInput(string input)
    {
        return input
            // Separate the different commands    
            .Split(", ")
            // Convert commands to more workable format
            .Select(command => (direction: command[0], distance: int.Parse(command[1..].ToString())));
    }
    
    protected override object SolvePart1(IEnumerable<(char turn, int distance)> input)
    {
        var currentPosition = (x: 0, y: 0);
        var direction = NORTH;
        
        foreach (var command in input)
        {
            direction = Turn(direction, command.turn);
            currentPosition = NextPosition(direction, currentPosition, command.distance);
        }
        
        return Math.Abs(currentPosition.x) + Math.Abs(currentPosition.y);
    }

    protected override object SolvePart2(IEnumerable<(char turn, int distance)> input)
    {
        var currentPosition = (x: 0, y: 0);
        var endOfSegment = (x: 0, y: 0);
        var direction = NORTH;
        var visitedPositions = new List<(int x, int y)> { currentPosition };
        
        foreach (var command in input)
        {
            
            direction = Turn(direction, command.turn);
            endOfSegment = NextPosition(direction, currentPosition, command.distance);

            do
            {
                currentPosition = NextPosition(direction, currentPosition, 1);
                if (visitedPositions.Contains(currentPosition))
                {
                    return Math.Abs(currentPosition.x) + Math.Abs(currentPosition.y);
                }

                visitedPositions.Add(currentPosition);
            } while (currentPosition != endOfSegment);
        }
        
        return Math.Abs(currentPosition.x) + Math.Abs(currentPosition.y);
    }
    
    private static char Turn(char fromDirection, char turnTo)
    {
        return (fromDirection, turnTo) switch
        {
            (NORTH, LEFT) => WEST,
            (NORTH, RIGHT) => EAST,
            (EAST, LEFT) => NORTH,
            (EAST, RIGHT) => SOUTH,
            (SOUTH, LEFT) => EAST,
            (SOUTH, RIGHT) => WEST,
            (WEST, LEFT) => SOUTH,
            (WEST, RIGHT) => NORTH,
            (_, _) => throw new ArgumentException($"Invalid direction or turn: {fromDirection}, {turnTo}"),
        };
    }

    private static (int x, int y) NextPosition(char direction, (int x, int y) currentPosition, int distance)
    {
        return direction switch
        {
            NORTH => (currentPosition.x, currentPosition.y + distance),
            EAST => (currentPosition.x + distance, currentPosition.y),
            SOUTH => (currentPosition.x, currentPosition.y - distance),
            WEST => (currentPosition.x - distance, currentPosition.y),
        };
    }
}
