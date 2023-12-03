using Basje.AdventOfCode.Y2023.Input;

namespace Basje.AdventOfCode.Y2023.D03;

public class Day03 : Solution<Schematic>
{
    protected override Schematic ParseInput(string input)
    {
        return new SchematicParser(input.PerLine().IgnoreEmptyLines()).GetSchematic();
    }

    protected override object SolvePart1(Schematic schematic)
    {
        foreach (var symbol in schematic.Symbols)
        {
            var numbers = schematic.GetNumbersAdjacentTo(symbol.Coordinates);
            foreach (var number in numbers)
            {
                number.MarkAsPartNumber();
            }
        }

        var partNumbers = schematic.GetPartNumbers();

        return partNumbers.Select(number => number.Value).Sum();
    }

    protected override object SolvePart2(Schematic schematic)
    {
        var sumOfGearRatios = 0;
        foreach (var symbol in schematic.Symbols)
        {
            if (symbol.Value != '*') continue;
            
            var numbers = schematic.GetNumbersAdjacentTo(symbol.Coordinates);
            
            if (numbers.Count() != 2) continue;

            sumOfGearRatios += numbers.First().Value * numbers.Last().Value;
        }

        return sumOfGearRatios;
    }
}