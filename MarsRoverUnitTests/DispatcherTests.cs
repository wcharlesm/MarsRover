using MarsRover.Implementations;
using System;
using Xunit;

namespace MarsRoverUnitTests
{
    public class DispatcherTests
    {
        Dispatcher dispatcher;

        public DispatcherTests()
        {
            dispatcher = new Dispatcher();
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
