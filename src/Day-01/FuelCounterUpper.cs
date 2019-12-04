using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2019.Day_01
{
    public static class FuelCounterUpper
    {
        public static int NaiveCalculateForMass(int mass)
        {
            return (int)Math.Round(mass / 3m, 0, MidpointRounding.ToNegativeInfinity) - 2;
        }

        public static int NaiveCalculateForMass(IEnumerable<int> masses)
        {
            return masses
                .Select(mass => NaiveCalculateForMass(mass))
                .Sum();
        }

        public static int ProperCalculateForMass(IEnumerable<int> masses)
        {
            return masses
                .Select(mass => ProperCalculateForMass(mass))
                .Sum();
        }

        public static int ProperCalculateForMass(int mass)
        {
            var fuel = NaiveCalculateForMass(mass);

            return fuel <= 0 ? 0 : fuel + ProperCalculateForMass(fuel);
        }
    }
}
