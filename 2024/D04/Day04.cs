namespace Basje.AdventOfCode.Y2024.D04;

public class Day04 : Solution<char[][]>
{
    protected override char[][] ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => line.ToArray())
            .ToArray();
    }

    protected override object SolvePart1(char[][] wordSearch)
    {
        var occurrences = 0;
        
        for (var line = 0; line < wordSearch.Length; line++)
        {
            for (var column = 0; column < wordSearch[line].Length; column++)
            {
                if (wordSearch[line][column] == 'X')
                {
                    occurrences += wordSearch.SearchFrom(line, column);
                } 
            }
        }
        
        return occurrences;
    }

    protected override object SolvePart2(char[][] wordSearch)
    {
        var occurrences = 0;
        
        for (var line = 0; line < wordSearch.Length; line++)
        {
            for (var column = 0; column < wordSearch[line].Length; column++)
            {
                if (wordSearch[line][column] == 'A')
                {
                    occurrences += wordSearch.SearchXFrom(line, column);
                } 
            }
        }
        
        return occurrences;
    }
    

}

internal static class Day04Extensions
{
    internal static int SearchFrom(this char[][] wordSearch, int line, int column)
    {
        return wordSearch.SearchUp(line, column)
               + wordSearch.SearchDown(line, column)
               + wordSearch.SearchLeft(line, column)
               + wordSearch.SearchRight(line, column)
               + wordSearch.SearchNE(line, column)
               + wordSearch.SearchNW(line, column)
               + wordSearch.SearchSE(line, column)
               + wordSearch.SearchSW(line, column);
    }

    internal static int SearchUp(this char[][] wordSearch, int line, int column)
    {
        if (column - 3 < 0) return 0;

        if (wordSearch[line][column - 1] == 'M'
            && wordSearch[line][column - 2] == 'A'
            && wordSearch[line][column - 3] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchDown(this char[][] wordSearch, int line, int column)
    {
        if (column + 3 >= wordSearch[line].Length) return 0;

        if (wordSearch[line][column + 1] == 'M'
            && wordSearch[line][column + 2] == 'A'
            && wordSearch[line][column + 3] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchLeft(this char[][] wordSearch, int line, int column)
    {
        if (line - 3 < 0) return 0;

        if (wordSearch[line - 1][column] == 'M'
            && wordSearch[line - 2][column] == 'A'
            && wordSearch[line - 3][column] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchRight(this char[][] wordSearch, int line, int column)
    {
        if (line + 3 >= wordSearch.Length) return 0;

        if (wordSearch[line + 1][column] == 'M'
            && wordSearch[line + 2][column] == 'A'
            && wordSearch[line + 3][column] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchNE(this char[][] wordSearch, int line, int column)
    {
        if (line - 3 < 0 || column + 3 >= wordSearch[line].Length) return 0;

        if (wordSearch[line - 1][column + 1] == 'M'
            && wordSearch[line - 2][column + 2] == 'A'
            && wordSearch[line - 3][column + 3] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchSE(this char[][] wordSearch, int line, int column)
    {
        if (line + 3 >= wordSearch.Length || column + 3 >= wordSearch[line].Length) return 0;

        if (wordSearch[line + 1][column + 1] == 'M'
            && wordSearch[line + 2][column + 2] == 'A'
            && wordSearch[line + 3][column + 3] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchSW(this char[][] wordSearch, int line, int column)
    {
        if (line + 3 >= wordSearch.Length || column - 3 < 0) return 0;

        if (wordSearch[line + 1][column - 1] == 'M'
            && wordSearch[line + 2][column - 2] == 'A'
            && wordSearch[line + 3][column - 3] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchNW(this char[][] wordSearch, int line, int column)
    {
        if (line - 3 < 0 || column - 3 < 0) return 0;

        if (wordSearch[line - 1][column - 1] == 'M'
            && wordSearch[line - 2][column - 2] == 'A'
            && wordSearch[line - 3][column - 3] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchXFrom(this char[][] wordSearch, int line, int column)
    {
        if (line - 1 < 0 
            || column - 1 < 0 
            || line + 1 >= wordSearch.Length 
            || column + 1 >= wordSearch[line].Length) 
            return 0;
        
        return wordSearch.SearchXNE(line, column)
               + wordSearch.SearchXNW(line, column)
               + wordSearch.SearchXSE(line, column)
               + wordSearch.SearchXSW(line, column) 
               == 2 ? 1 : 0;
    }
    
    internal static int SearchXNE(this char[][] wordSearch, int line, int column)
    {
        if (wordSearch[line + 1][column - 1] == 'M' && wordSearch[line - 1][column + 1] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchXSE(this char[][] wordSearch, int line, int column)
    {
        if (wordSearch[line - 1][column - 1] == 'M' && wordSearch[line + 1][column + 1] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchXSW(this char[][] wordSearch, int line, int column)
    {
        if (wordSearch[line - 1][column + 1] == 'M' && wordSearch[line + 1][column - 1] == 'S')
        {
            return 1;
        }

        return 0;
    }
    
    internal static int SearchXNW(this char[][] wordSearch, int line, int column)
    {
        if (wordSearch[line + 1][column + 1] == 'M' && wordSearch[line - 1][column - 1] == 'S')
        {
            return 1;
        }

        return 0;
    }
}
