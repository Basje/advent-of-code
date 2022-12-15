namespace Basje.AdventOfCode.Y2022.D15;

public partial class Day15 : ISolution
{
    private readonly IEnumerable<((int x, int y) sensor, (int x, int y) beacon)> locations;

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
            .Select(line => (sensor: line[0], beacon: line[1]));
    }

    public object SolvePart1()
    {
        const int ROW = 2_000_000;
        var intersectingCoords = new List<int>();
        var beaconCount = locations.Where(line => line.beacon.y == ROW).Select(line => line.beacon).Distinct().Count();

        foreach (var line in locations)
        {
            var intersectingRowXs = line.GetIntersectionsWith(ROW);
            intersectingCoords.AddRange(intersectingRowXs);
            intersectingCoords = intersectingCoords.Distinct().ToList();
        }
        return intersectingCoords.Distinct().Count() - beaconCount;
    }

    public object SolvePart2()
    {
        return -1;
    }
}

public static class Extensions
{
    public static IEnumerable<int> GetIntersectionsWith(this ((int x, int y) sensor, (int x, int y) beacon) line, int row)
    {
        var (intersects, radius, distance) = line.IntersectsWithRow(row);
        if (intersects)
        {
            var diff = radius - distance;
            return Enumerable.Range(line.sensor.x - diff, diff * 2 + 1);
        }
        return Enumerable.Empty<int>();
    }

    public static int ManhattanDistanceTo(this (int x, int y) left, (int x, int y) right)
    {
        return Math.Abs(left.x - right.x) + Math.Abs(left.y - right.y);
    }

    public static (bool intersects, int mDistance, int iDistance) IntersectsWithRow(this ((int x, int y) sensor, (int x, int y) beacon) line, int row)
    {
        var manhattanDistance = line.sensor.ManhattanDistanceTo(line.beacon);
        var intersects = line.sensor.y - manhattanDistance <= row && row <= line.sensor.y + manhattanDistance;

        if (!intersects)
        {
            return (false, manhattanDistance, 0);
        }

        var intersectDistance = Math.Abs(row - line.sensor.y);
        return (intersects, manhattanDistance, intersectDistance);
    }
}
