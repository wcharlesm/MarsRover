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
        public void HappyPath()
        {
            dispatcher.ReceiveInstructions("");
        }
    }
}
