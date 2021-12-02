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
        public void TestNaiveCalculation()
        {
            Assert.AreEqual(2, FuelCounterUpper.NaiveCalculateForMass(12));
            Assert.AreEqual(2, FuelCounterUpper.NaiveCalculateForMass(14));
            Assert.AreEqual(654, FuelCounterUpper.NaiveCalculateForMass(1969));
            Assert.AreEqual(33583, FuelCounterUpper.NaiveCalculateForMass(100756));
        }

        [Test]
        public void TestNaiveCalculationSum()
        {
            Assert.AreEqual(34241, FuelCounterUpper.NaiveCalculateForMass(new int[] { 12, 14, 1969, 100756 }));
        }

        [Test]
        public void TestProperCalculation()
        {
            Assert.AreEqual(2, FuelCounterUpper.ProperCalculateForMass(12));
            Assert.AreEqual(2, FuelCounterUpper.ProperCalculateForMass(14));
            Assert.AreEqual(966, FuelCounterUpper.ProperCalculateForMass(1969));
            Assert.AreEqual(50346, FuelCounterUpper.ProperCalculateForMass(100756));
        }

        [Test]
        public void TestProperCalculationSum()
        {
            Assert.AreEqual(51316, FuelCounterUpper.ProperCalculateForMass(new int[] { 12, 14, 1969, 100756 }));
        }
    }
}
