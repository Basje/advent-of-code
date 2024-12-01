using Basje.AdventOfCode.Y2024.Input;

namespace Basje.AdventOfCode.Y2024.D01;

public class Day01 : Solution<IEnumerable<(int Left, int Right)>>
{
    protected override IEnumerable<(int Left, int Right)> ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(line => (Left: int.Parse(line[0]), Right: int.Parse(line[1])));
    }
    
    protected override object SolvePart1(IEnumerable<(int Left, int Right)> input)
    {
        List<int> leftList = [];
        List<int> rightList = [];

        input.ToList().ForEach(line =>
        {
            leftList.Add(line.Left);
            rightList.Add(line.Right);
        });

        var orderedLeftList = leftList.Order().ToArray();
        var orderedRightList = rightList.Order().ToArray();

        List<int> distances = [];

        for (var index = 0; index < orderedLeftList.Length && index < orderedRightList.Length; index++)
        {
            distances.Add(Math.Abs(orderedLeftList[index] - orderedRightList[index] ));
        }

        return distances.Sum();
    }

    protected override object SolvePart2(IEnumerable<(int Left, int Right)> input)
    {
        List<int> leftList = [];
        List<int> rightList = [];

        input.ToList().ForEach(line =>
        {
            leftList.Add(line.Left);
            rightList.Add(line.Right);
        });

        List<int> similarityScore = [];
        
        leftList.ForEach(number =>
        {
            var occurrences = rightList.Count(entry => entry == number);
            similarityScore.Add(number * occurrences);
        });
        
        return similarityScore.Sum();
    }
}
