using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Command
{
    [TestFixture]
    public class CommandTest
    {
        [Test]
        [Category("Step1")]
        public void RoverTest()
        {
            var input = @"5 5
1 1 N

";
            var marsRover = new MarsRover();
            marsRover.Run(input).Should().Be("1 1 N");
        }

        [Test]
        [Category("Step2")]
        public void RoverTurns()
        {
            var input = @"5 5
1 1 N
L
";
            var marsRover = new MarsRover();
            marsRover.Run(input).Should().Be("1 1 W");
        }
        [Test]
        [Category("Step2")]
        public void RoverTurnRightTest()
        {
            var input = @"5 5
1 2 N
R
";
            var marsRover = new MarsRover();
            marsRover.Run(input).Should().Be("1 2 E");
        }

        [Category("Step2")]
        [Test, TestCaseSource(typeof(RoverTestCases), "TurnTestCases")]
        public string RoverSingleTurns(string input)
        {
            var marsRover = new MarsRover();
            return marsRover.Run(input);
        }

        [Category("Step3")]
        [Test, TestCaseSource(typeof(RoverTestCases), "MoveTestCases")]
        public string RoverSingleMoves(string input)
        {
            var marsRover = new MarsRover();
            return marsRover.Run(input);
        }
    }

    public class RoverTestCases
    {
        private static TestCaseData TestCaseFactory(string StartPos, string Commands, string EndPos)
        {
            var input = $"1 1 N\n{StartPos}\n{Commands}";  
            var Turn = "Bad Test Code";
            if (Commands.Equals("L")) Turn="Left";
            if (Commands.Equals("R")) Turn="Right";
            return new TestCaseData(input).Returns(EndPos).SetName($"{{C}}.{{m}} \n Start:[{StartPos}]=>Cmd:[{Turn}]=>End:[{EndPos}]");
        }
        public static IEnumerable<TestCaseData> TurnTestCases
        {
            get
            {
                yield return TestCaseFactory("1 1 N", "L", "1 1 W");
                yield return TestCaseFactory("1 1 N", "R", "1 1 E");
                yield return TestCaseFactory("1 1 E", "L", "1 1 N");
                yield return TestCaseFactory("1 1 E", "R", "1 1 S");
                yield return TestCaseFactory("1 1 S", "L", "1 1 E");
                yield return TestCaseFactory("1 1 S", "R", "1 1 W");
                yield return TestCaseFactory("1 1 W", "L", "1 1 S");
                yield return TestCaseFactory("1 1 W", "R", "1 1 N");
            }
        }  
        public static IEnumerable<TestCaseData> MoveTestCases
        {
            get
            {
                yield return TestCaseFactory("1 1 N", "M", "1 2 N");
                yield return TestCaseFactory("1 1 E", "M", "2 1 E");
                yield return TestCaseFactory("1 1 W", "M", "0 1 W");
                yield return TestCaseFactory("1 1 S", "M", "1 0 S");
            }
        }  

    }

}