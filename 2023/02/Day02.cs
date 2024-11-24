using Basje.AdventOfCode.Y2023.Input;

namespace Basje.AdventOfCode.Y2023.D02;

public class Day02 : Solution<IEnumerable<Game>>
{
    protected override IEnumerable<Game> ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            // Split games from sets
            .Select(game => game.Split(": "))
            // Split game data. Split into separate sets. 
            .Select(game => (
                Id: game[0].Split(" "),
                Sets: game[1].Split("; ")))
            // Isolate game ID. Split sets into cube data.
            .Select(game => (
                Id: game.Id[1],
                Sets: game.Sets.Select(set => set.Split(", "))))
            // Convert game ID to integer. Split cube data.
            .Select(game => (
                Id: int.Parse(game.Id),
                Sets: game.Sets.Select(set => set.Select(cubes => cubes.Split(" ")))))
            // 
            .Select(game => (
                game.Id,
                Sets: game.Sets.Select(set => set.Select(cubes => (Color: cubes[1], Count: int.Parse(cubes[0]))))))

            .Select(game => new Game() { Id = game.Id, Sets = game.Sets.Select(set => new Set() { Cubes = set }) });
    }

    protected override object SolvePart1(IEnumerable<Game> input)
    {
        const string red = "red";
        const string green = "green";
        const string blue = "blue";

        const int maxRedCubes = 12;
        const int maxGreenCubes = 13;
        const int maxBlueCubes = 14;

        var sumOfIds = 0;

        foreach (var game in input)
        {
            var possible = true;

            foreach (var set in game.Sets)
            {
                foreach (var cubes in set.Cubes)
                {
                    possible = cubes.Color switch
                    {
                        red => possible && cubes.Count <= maxRedCubes,
                        green => possible && cubes.Count <= maxGreenCubes,
                        blue => possible && cubes.Count <= maxBlueCubes,
                    };
                }
            }

            if (possible)
            {
                sumOfIds += game.Id;
            }
        }

        return sumOfIds;
    }

    protected override object SolvePart2(IEnumerable<Game> input)
    {
        const string red = "red";
        const string green = "green";
        const string blue = "blue";

        var sumOfPowers = 0;

        foreach (var game in input)
        {
            var minRedCubes = 0;
            var minGreenCubes = 0;
            var minBlueCubes = 0;
            
            foreach (var set in game.Sets)
            {
                foreach (var cubes in set.Cubes)
                {
                    switch (cubes.Color)
                    {
                        case red:
                            minRedCubes = Math.Max(minRedCubes, cubes.Count);
                            break;
                        case green:
                            minGreenCubes = Math.Max(minGreenCubes, cubes.Count);
                            break;
                        case blue:
                            minBlueCubes = Math.Max(minBlueCubes, cubes.Count);
                            break;
                    }
                }
            }

            sumOfPowers += minRedCubes * minGreenCubes * minBlueCubes;
        }

        return sumOfPowers;
    }
}