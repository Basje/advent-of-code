namespace Basje.AdventOfCode.Y2023.D03;

public class Schematic
{
    private readonly List<Number> numbers = [];
    private readonly List<Symbol> symbols = [];

    public void Add(Number number) => numbers.Add(number);
    public void Add(Symbol symbol) => symbols.Add(symbol);

    public List<Symbol> Symbols => symbols;

    public IEnumerable<Number> GetNumbersAdjacentTo(Coordinates coordinates)
    {
        return numbers
            .Where(number => number.AdjacentAreaIncludes(coordinates));
    }

    public IEnumerable<Number> GetPartNumbers() => numbers.Where(number => number.IsPartNumber);

}