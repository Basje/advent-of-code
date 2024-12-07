namespace Basje.AdventOfCode.Y2024.D07;

public class Day07 : Solution<long[][]>
{
    protected override long[][] ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => line.Split(": ".ToArray(), StringSplitOptions.RemoveEmptyEntries))
            .Select(line => line.Select(long.Parse).ToArray())
            .ToArray();
    }

    protected override object SolvePart1(long[][] equations)
    {
        long sum = 0;

        foreach (var equation in equations)
        {
            var test = equation.First();
            var values = CalculateTestValues(equation.Skip(1).Take(1).ToList(), equation.Skip(2).ToList());

            if (values.Contains(test))
            {
                sum += test;
            }
        }

        return sum;
    }

    protected override object SolvePart2(long[][] equations)
    {
        long sum = 0;

        foreach (var equation in equations)
        {
            var test = equation.First();
            var values = CalculateTestValues2(equation.Skip(1).Take(1).ToList(), equation.Skip(2).ToList());

            if (values.Contains(test))
            {
                sum += test;
            }
        }

        return sum;
    }

    private List<long> CalculateTestValues(List<long> values, List<long> input)
    {
        if (input.Count == 0) return values;

        List<long> newValues = [];
        var firstInput = input.First();

        foreach (var number in values)
        {
            newValues.Add(number + firstInput); 
            newValues.Add(number * firstInput);
        }

        return CalculateTestValues(newValues, input.Skip(1).ToList());
    }
    
    private List<long> CalculateTestValues2(List<long> values, List<long> input)
    {
        if (input.Count == 0) return values;

        List<long> newValues = [];
        var firstInput = input.First();

        foreach (var number in values)
        {
            newValues.Add(number + firstInput); 
            newValues.Add(number * firstInput);
            newValues.Add(long.Parse($"{number}{firstInput}"));
        }

        return CalculateTestValues2(newValues, input.Skip(1).ToList());
    }
}

internal static class Day07Extensions
{

}
