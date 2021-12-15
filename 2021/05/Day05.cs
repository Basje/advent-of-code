namespace Basje.AdventOfCode.Y2021.D05
{
    public class Day05 : ISolution
    {
        private readonly List<Line> lines;

        public Day05(IEnumerable<string> input)
        {
            lines = input
                // Split into raw data and remove arrow characters
                .Select(row => row.Split(" -> "))
                // Split into coordinate digits and remove commas
                .Select(row => row.Select(data => data.Split(",")))
                // Parse into integers and convert to arrays
                .Select(row => row.Select(data => data.Select(item => int.Parse(item)).ToArray()).ToArray())
                // Create Point array of coordinates
                .Select(row => new Point[] { new Point(row[0][0], row[0][1]), new Point(row[1][0], row[1][1]) })
                // Use points to create a Line
                .Select(points => new Line(points[0], points[1]))

                .ToList();
        }

        public string SolvePart1()
        {
            var allPoints = new List<Point>();

            foreach(var line in lines)
            {
                if (line.IsVertical || line.IsHorizontal)
                {
                    allPoints.AddRange(line.ToPoints());
                }
            }

            var intersections = allPoints
                .GroupBy(point => point)
                .ToDictionary(group => group.Key, group => group.Count());

            return intersections
                .Where(entry => entry.Value > 1)
                .Count()
                .ToString();
        }

        public string SolvePart2()
        {
            var allPoints = new List<Point>();

            foreach (var line in lines)
            {
                allPoints.AddRange(line.ToPoints());
            }

            var intersections = allPoints
                .GroupBy(point => point)
                .ToDictionary(group => group.Key, group => group.Count());

            return intersections
                .Where(entry => entry.Value > 1)
                .Count()
                .ToString();
        }
    }
}
