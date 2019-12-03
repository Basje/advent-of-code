using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode_2019.Day_01
{
    public static class FuelCounterUpper
    {
        public static int CalculateForMass(int mass)
        {
            return (int)Math.Round(mass / 3m, 0, MidpointRounding.ToNegativeInfinity) - 2;
        }

        public static int ReCalculateForMass(int mass)
        {
            var fuel = CalculateForMass(mass);

            if (fuel > 0)
            {
                return fuel + ReCalculateForMass(fuel);
            }

            return 0;
        }
    }
}