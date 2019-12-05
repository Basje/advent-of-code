using AdventOfCode_2019.Day_02;
using NUnit.Framework;

namespace UnitTests
{
    public class Day02Tests
    {
        [Test]
        public void ProgramResultTest()
        {
            Assert.AreEqual(3500, IntcodeProgram.FromString("1,9,10,3,2,3,11,0,99,30,40,50").Run());
            Assert.AreEqual(2, IntcodeProgram.FromString("1,0,0,0,99").Run());
            Assert.AreEqual(2, IntcodeProgram.FromString("2,3,0,3,99").Run());
            Assert.AreEqual(2, IntcodeProgram.FromString("2,4,4,5,99,0").Run());
            Assert.AreEqual(30, IntcodeProgram.FromString("1,1,1,4,99,5,6,0,99").Run());
        }
    }
}
