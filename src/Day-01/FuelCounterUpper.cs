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
    }
}