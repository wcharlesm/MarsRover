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
1 2 N

";
            var marsRover = new MarsRover();
            marsRover.Run(input).Should().Be("1 1 N");
        }
    }
}