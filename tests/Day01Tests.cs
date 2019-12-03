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
        public void TestReCalculation()
        {
            Assert.AreEqual(2, FuelCounterUpper.ReCalculateForMass(12));
            Assert.AreEqual(2, FuelCounterUpper.ReCalculateForMass(14));
            Assert.AreEqual(966, FuelCounterUpper.ReCalculateForMass(1969));
            Assert.AreEqual(50346, FuelCounterUpper.ReCalculateForMass(100756));
        }

        [Test]
        public void TestSimpleCalculation()
        {
            Assert.AreEqual(2, FuelCounterUpper.CalculateForMass(12));
            Assert.AreEqual(2, FuelCounterUpper.CalculateForMass(14));
            Assert.AreEqual(654, FuelCounterUpper.CalculateForMass(1969));
            Assert.AreEqual(33583, FuelCounterUpper.CalculateForMass(100756));
        }
    }
}