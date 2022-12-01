namespace Basje.AdventOfCode.Y2021.Input
{
    public static class Input
    {
        /// <summary>
        /// Location of the root of the Advent of Code repository.
        /// </summary>
        private static readonly string repositoryDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).FullName;

        /// <summary>
        /// Define the Advent of Code year.
        /// </summary>
        /// <param name="year">Event year</param>
        /// <returns></returns>
        public static Year Year(int year)
        {
            return new Year(year);
        }

        internal static IEnumerable<string> ReadLines(int year, int day)
        {
            var location = DetermineInputFileLocation(year, day);

            return File.ReadAllLines(location);
        }

        internal static string ReadText(int year, int day)
        {
            var location = DetermineInputFileLocation(year, day);

            return File.ReadAllText(location);
        }

        private static string DetermineInputFileLocation(int year, int day)
        {
            var paddedDay = day.ToString().PadLeft(2, '0');

            //return Path.Combine(new string[] {
            //    repositoryDirectory,
            //    $"{year}",
            //    $"Day-{paddedDay}",
            //    "input.txt",
            //});
            return Path.Combine(
                repositoryDirectory,
                //year.ToString(),
                $"{paddedDay}",
                "input.txt"
            );
        }

        public static IEnumerable<ArraySegment<T>> SlidingWindow<T>(this IEnumerable<T> list, int size)
        {
            size = Math.Max(1, size);
            var array = list.ToArray();

            for (var i = 0; i <= list.Count() - size ; i++)
            {
                yield return new ArraySegment<T>(array, i, size);
            }
        }
    }
}