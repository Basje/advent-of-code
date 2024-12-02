namespace Basje.AdventOfCode.Y2024.D02;

public class Day02 : Solution<List<List<int>>>
{
    protected override List<List<int>> ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(report => report.Split(' '))
            .Select(report => report.Select(int.Parse).ToList())
            .ToList();
    }

    protected override object SolvePart1(List<List<int>> reports)
    {
        return reports
            .Select(report => report.Steps().ToList())
            .Count(steps => steps.AllInRange() && (steps.AllIncreasing() || steps.AllDecreasing()));
    }

    protected override object SolvePart2(List<List<int>> reports)
    {
        var safeReports = reports
            .Where(report =>
            {
                var steps = report.Steps().ToList();
                return steps.AllInRange() && (steps.AllIncreasing() || steps.AllDecreasing());
            })
            .ToList();

        var unsafeReports = reports.Except(safeReports).ToList();
        
        unsafeReports.ForEach(report =>
        {
            var wrongStep = report.Steps().ToList().FindIndex((number) => report.IsIncreasing() ? number is < 1 or > 3 : number is < -3 or > -1);

            for (var index = Math.Max(0, wrongStep - 1); index < Math.Min(wrongStep + 2, report.Count); index++)
            {
                var filteredReport = report.ToList();
                filteredReport.RemoveAt(index);
                var steps = filteredReport.Steps().ToList();

                if (steps.AllInRange() && (steps.AllIncreasing() || steps.AllDecreasing()))
                {
                    safeReports.Add(report);
                    break;
                }
            }
        });

        return safeReports.Count;
    }
}

internal static class Day02Extensions
{
    internal static bool AllInRange(this List<int> numbers)
    {
        return numbers.Count(number => Math.Abs(number) is >= 1 and <= 3) == numbers.Count;
    }
    
    internal static bool AllDecreasing(this List<int> numbers)
    {
        return numbers.CountDecreasing() == numbers.Count;
    }
    
    internal static bool AllIncreasing(this List<int> numbers)
    {
        return numbers.CountIncreasing() == numbers.Count;
    }

    internal static IEnumerable<int> Steps(this IEnumerable<int> numbers)
    {
        foreach (var levelSet in numbers.SlidingWindow(2))
        {
            var left = levelSet[0];
            var right = levelSet[1];

            yield return right - left;
        }
    }

    internal static bool IsIncreasing(this List<int> numbers)
    {
        return numbers[1] > numbers[0];
    }
    
    private static int CountDecreasing(this List<int> numbers)
    {
        return numbers.Count(number => number < 0);
    }

    private static int CountIncreasing(this List<int> numbers)
    {
        return numbers.Count(number => number > 0);
    }
}
