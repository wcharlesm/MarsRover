using MarsRover.Implementations;
using System;
using Xunit;

namespace MarsRoverUnitTests
{
    public class IntegrationTest
    {
        [Fact]
        public void AddRoverHappyPath()
        {
            var dispatch = "5 5\n1 1 N\nMRML";
            var expectedOutput = "2 2 N";

            var plateauMap = new PlateauMap();
            var dispatcher = new Dispatcher(plateauMap);

            var result = dispatcher.ReceiveInstructions(dispatch);

            Assert.Equal(expectedOutput, result);
            
        }
    }
}
