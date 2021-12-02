using System.Collections.Generic;

namespace AdventOfCode_2019.Day_03
{
    sealed internal class Path
    {
        internal Path(IList<string> directions)
        {
            Directions = directions;
        }

        internal IList<string> Directions { get; }
    }
}
