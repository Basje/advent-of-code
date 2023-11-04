namespace Basje.AdventOfCode.Y2022.Input
{
    public record Day
    {
        private readonly int year;
        private readonly int day;

        internal Day(int year, int day)
        {
            this.year = year;
            this.day = day;
        }

        public IEnumerable<string> ReadLines()
        {
            return Input.ReadLines(year, day);
        }

        public IEnumerable<T> ReadLines<T>(Func<string, T> converter)
        {
            return ReadLines().Select(converter);
        }

        public string ReadText()
        {
            return Input.ReadText(year, day);
        }


    }
}
