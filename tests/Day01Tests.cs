using AdventOfCode_2019.Day_01;
using NUnit.Framework;

namespace UnitTests
{
    public class Day01Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TextExampleInput()
        {
            Assert.AreEqual(FuelCounterUpper.CalculateForMass(12), 2);
            Assert.AreEqual(FuelCounterUpper.CalculateForMass(14), 2);
            Assert.AreEqual(FuelCounterUpper.CalculateForMass(1969), 654);
            Assert.AreEqual(FuelCounterUpper.CalculateForMass(100756), 33583);
        }
    }
}