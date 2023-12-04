namespace Basje.AdventOfCode.Y2023.D04;

public record Card(int Number, IEnumerable<int> WinningNumbers, IEnumerable<int> OurNumbers);