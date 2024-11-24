namespace Basje.AdventOfCode.Y2023.D03;

public class SchematicParser
{
    private readonly List<string> input;
    
    public SchematicParser(IEnumerable<string> input)
    {
        this.input = input.ToList();
    }

    public IEnumerable<Token> Tokens()
    {
        for (var line = 0; line < input.Count; line++)
        {
            for (var location = 0; location < input[line].Length; location++)
            {
                yield return new Token(input[line][location], new Coordinates(location, line));
            }
            // This part was missing initially, passed without it for example data, but caused nasty bug with real data.
            yield return new Token('\n', new Coordinates(-1, -1));
        } 
    }

    public Schematic GetSchematic()
    {
        var schematic = new Schematic();
        var numbers = new List<Token>();

        foreach (var token in Tokens())
        {
            if (token.IsNumber)
            {
                numbers.Add(token);
                continue;
            }
            
            if (token.IsSymbol)
            {
                schematic.Add(new Symbol(token.Value, token.Coordinates));
            }            

            if (numbers.Count > 0)
            {
                var value = numbers.Aggregate(0, (number, token) => number * 10 + token.Digit);
                var left = numbers.First().Coordinates;
                var right = numbers.Last().Coordinates;
                schematic.Add(new Number(value, left, right));
                numbers.Clear();
            }
        }

        return schematic;
    }
}