using MarsRover.Implementations;
using MarsRover.Interfaces;
using Moq;
using System;
using Xunit;

namespace MarsRoverUnitTests
{
    public class DispatcherTests
    {
        Dispatcher dispatcher;

        public DispatcherTests()
        {
            var plateauMap = new Mock<IPlateauMap>();
            dispatcher = new Dispatcher(plateauMap.Object);
        }

        [Fact]
        public void ExampleHappyPath()
        {
            var dispatch = "5 5\n1 1 N\nMRML";
            var expectedOutput = "2 2 N";

            var output = dispatcher.ReceiveInstructions(dispatch);

            Assert.Equal(expectedOutput, output);
        }
    }
}
