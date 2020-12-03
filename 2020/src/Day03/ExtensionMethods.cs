using System.Collections.Generic;

namespace AdventOfCode_2020.Day03
{
    public static class ExtensionMethods
    {
        public static bool IsTree(this IList<string> map, int x, int y)
        {
            const char TREE = '#';

            if (map is null)
            {
                return false;
            }

            var mapWidth = map[0].Length;
            var terrain = map[y][x % mapWidth];

            return terrain == TREE;
        }
    }
}