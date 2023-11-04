namespace Basje.AdventOfCode.Y2022.D15;

public partial class Day15 : ISolution
{
    private readonly IEnumerable<Pair> locations;

    public Day15(string input)
    {
        locations = input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Replace("Sensor at x=", ""))
            .Select(line => line.Replace("closest beacon is at x=", ""))
            .Select(line => line.Replace("y=", ""))
            .Select(line => line.Split(": "))
            .Select(line => line.Select(coords => coords.Split(", ")))
            .Select(line => line.Select(coords => coords.Select(int.Parse).ToArray()))
            .Select(line => line.Select(coords => (x: coords[0], y: coords[1])).ToArray())
            .Select(line => (sensor: new Sensor { X = line[0].x, Y = line[0].y }, beacon: new Beacon { X = line[1].x, Y = line[1].y }))
            .Select(line => new Pair(line.sensor, line.beacon));
    }

    public object SolvePart1()
    {
        const int ROW = 2_000_000;
        var intersections = new List<Range>();
        var beaconCount = locations
            .Where(pair => pair.Beacon.Y == ROW)
            .Select(pair => pair.Beacon)
            .Distinct()
            .Count();

        foreach (var pair in locations)
        {
            var slice = pair.RowSlice(ROW);
            if (slice != null) {
                intersections.Add(slice);
            }
        }

        return intersections.Count() - beaconCount;
    }

    public object SolvePart2()
    {
        const int MIN = 0;
        const int MAX = 4_000_000;

        var tuningFrequency = 0;

        //for (var row = MIN; row <= MAX; row++)
        //{
        //    var possibleXs = Enumerable.Range(0, 4_000_000);
        //    var beaconCount = locations
        //        .Where(line => line.beacon.y == row)
        //        .Select(line => line.beacon)
        //        .Distinct()
        //        .Count();

        //    foreach (var line in locations)
        //    {
        //        var intersectingRowXs = line.GetIntersectionsWith(row);
        //        possibleXs = possibleXs.Except(intersectingRowXs);
        //    }

        //    if (possibleXs.Any())
        //    {
        //        tuningFrequency = possibleXs.First() * MAX + row;
        //        break;
        //    }

        //}
        
        return tuningFrequency;
    }
}

public static class Extensions
{
    public static int Count(this IEnumerable<Range> ranges)
    {
        var input = ranges.OrderBy(range => range.Start).ToList();
        var min = ranges.Min(range => range.Start);
        var max = ranges.Max(range => range.End);
        var count = 0;

        for ( var i = min; i <= max; i++)
        {
            foreach ( var range in input)
            {
                if (range.Contains(i))
                {
                    count++;
                    continue;
                }
            }
        }
        return count;
    }

    public static bool Contains(this Range range, int value)
    {
        return range.Start <= value && value <= range.End; 
    }
}

public record Pair
{
    private readonly int manhattanDistance;

    public Pair(Sensor sensor, Beacon beacon)
    {
        Sensor = sensor;
        Beacon = beacon;

        manhattanDistance = Math.Abs(Sensor.X - Beacon.X) + Math.Abs(Sensor.Y - Beacon.Y);
    }

    public Sensor Sensor { get; private init; }
    public Beacon Beacon { get; private init; }

    public int ManhattanDistance => manhattanDistance;

    public Range? RowSlice(int row)
    {
        var intersects = Sensor.Y - ManhattanDistance <= row && row <= Sensor.Y + ManhattanDistance;

        if (!intersects)
        {
            return null;
        }

        var diff = ManhattanDistance - Math.Abs(row - Sensor.Y);
        return new Range(Sensor.X - diff, Sensor.X + diff);
    }
}

public readonly struct Sensor
{
    public required int X { get; init; }
    public required int Y { get; init; }
}

public readonly struct Beacon
{
    public required int X { get; init; }
    public required int Y { get; init; }
}

public record Range
{
    public Range(int start, int end)
    {
        Start = start;
        End = end;
    }

    public int Start { get; private init; }
    public int End { get; private init; }

    public bool Overlaps(Range range)
    {
        return false;
    }
}
