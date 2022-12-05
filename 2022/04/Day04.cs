namespace Basje.AdventOfCode.Y2022.D04;

public class Day04 : ISolution
{
    private readonly IEnumerable<(IEnumerable<int> left, IEnumerable<int> right)> assignments;

    public Day04(string input)
    {
        assignments = input
            // Split into separate section assignments
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            // Split into a pair of sections
            .Select(pair => pair.Split(','))
            // Convert to a tuple
            .Select(sections => (left: sections.First(), right: sections.Last()))
            // Split range of sections into start and end numbers
            .Select(sections => (left: sections.left.Split('-').Select(int.Parse), right: sections.right.Split('-').Select(int.Parse)))
            // Convert start and end numbers into ranges
            .Select(sections => (
                left: Enumerable.Range(sections.left.First(), sections.left.Last() - sections.left.First() + 1),
                right: Enumerable.Range(sections.right.First(), sections.right.Last() - sections.right.First() + 1)
            ));
    }

    public object SolvePart1()
    {
        return assignments
            // Filter the sections that fully overlap...
            .Where(pair => 
                // Ad hoc list of both range sizes
                new[] { pair.left.Count(), pair.right.Count() }
                    // The full overlap will have the size of the shortest range
                    .Contains(pair.left.Intersect(pair.right).Count())
            )
            // ... and count them
            .Count();
    }

    public object SolvePart2()
    {
        return assignments
            // Filter the sections that partially overlap...
            .Where(pair => pair.left.Intersect(pair.right).Any()
            )
            // ... and count them
            .Count();
    }
}
