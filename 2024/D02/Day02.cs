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
            .Count(report => report.Steps().AreSafe());
    }

    protected override object SolvePart2(List<List<int>> reports)
    {
        var safeReports = reports
            .Where(report => report.Steps().AreSafe())
            .ToArray();

        var fixedReports = reports
            .Except(safeReports)
            .Select(report => (Report: report, Steps: report.Steps(), Increasing: report[^1] > report[0]))
            .Select(data => (Report: data.Report, WrongStep: data.FindFirstWrongStep()))
            .Count(data => data.Report.CompensateForStep(data.WrongStep).Any(report => report.Steps().AreSafe()));

        return safeReports.Length + fixedReports;
    }
}

internal static class Day02Extensions
{
    internal static bool AreSafe(this IEnumerable<int> steps)
    {
        return steps.All(n => n is >= 1 and <= 3)
            || steps.All(n => n is >= -3 and <= -1);
    }

    internal static int FindFirstWrongStep(this (List<int> Report, List<int> Steps, bool Increasing) data)
    {
        return data
            .Steps
            .FindIndex((number) => data.Increasing  ? number is < 1 or > 3 : number is < -3 or > -1);
    }

    internal static List<int>[] CompensateForStep(this List<int> report, int position)
    {
        return 
        [
            // Create new reports without the values that cause the
            // wrong step at "position" in an attempt to compensate.
            [..report[..position], ..report[(position+1)..]],
            [..report[..(position+1)], ..report[(position+2)..]]
        ];
    }

    internal static List<int> Steps(this IEnumerable<int> numbers)
    {
        return numbers
            .Zip(numbers.Skip(1), Tuple.Create)
            .Select(tuple => tuple.Item2 - tuple.Item1)
            .ToList();
    }
}
