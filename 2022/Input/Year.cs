namespace Basje.AdventOfCode.Y2022.Input
{
    public record Year
    {
        private readonly int year;

        internal Year(int year)
        {
            this.year = year;
        }

        public Day Day(int day)
        {
            return new Day(year, day);
        }        
    }
}
