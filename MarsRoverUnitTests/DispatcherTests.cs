using MarsRover.Implementations;
using MarsRover.Interfaces;
using Moq;
using System;
using Xunit;

namespace MarsRoverUnitTests
{
    public class DispatcherTests
    {
        private Mock<IPlateauMap> _plateauMap;

        Dispatcher dispatcher;

        public DispatcherTests()
        {
            var plateauMap = new Mock<IPlateauMap>();
            dispatcher = new Dispatcher(plateauMap.Object);
        }

        [Fact]
        public void MapIsSetHappyPath()
        {
            var dispatch = "5 5\n1 1 N\nMRML";

            var output = dispatcher.ReceiveInstructions(dispatch);

            _plateauMap.Verify(x => x.SetMap(5, 5), Times.Once);
        }

        [Fact]
        public void FullHappyPath()
        {
            var dispatch = "5 5\n1 1 N\nMRML";
            var expectedOutput = "2 2 N";

            var output = dispatcher.ReceiveInstructions(dispatch);


            Assert.Equal(expectedOutput, output);
        }
    }
}
