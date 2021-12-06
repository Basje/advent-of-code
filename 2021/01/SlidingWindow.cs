namespace Basje.AdventOfCode.Y2021.D01
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<ArraySegment<T>> SlidingWindow<T>(this IEnumerable<T> list, int size)
        {
            size = Math.Max(1, size);
            var array = list.ToArray();

            for (var i = 0; i <= list.Count() - size; i++)
            {
                yield return new ArraySegment<T>(array, i, size);
            }
        }
    }
}
