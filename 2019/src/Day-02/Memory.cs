using System;
using System.Collections.Generic;

namespace AdventOfCode_2019.Day_02
{
    internal class Memory
    {
        public Memory(IList<int> data)
        {
            Data = new List<int>(data);
        }

        private List<int> Data { get; }

        internal int GetAddress(int index)
        {
            return Data[index];
        }

        internal IList<int> GetAddressRange(int start, int size)
        {
            var safeSize = Math.Min(size, Data.Count - start);

            return Data.GetRange(start, safeSize);
        }

        internal void SetAddress(int index, int value)
        {
            if (index >= Data.Count) return;

            Data[index] = value;
        }
    }
}
