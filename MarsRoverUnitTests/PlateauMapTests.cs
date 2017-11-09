using MarsRover.Implementations;
using MarsRover.Interfaces;
using Moq;
using System;
using Xunit;

namespace MarsRoverUnitTests
{
    public class PlateauMapTests
    {
        private PlateauMap _plateauMap;

        public PlateauMapTests()
        {
            _plateauMap = new PlateauMap();
        }

        [Fact]
        public void SetMapHappyPath()
        {
            _plateauMap.SetMap(5, 5);
        }

        [Fact]
        public void SetMapNegativeX()
        {
            Exception ex = Assert.Throws<Exception>(() => _plateauMap.SetMap(-5, 5));
            Assert.Equal("Negative x Coordinate", ex.Message);
        }

        [Fact]
        public void SetMapNegativeY()
        {
            Exception ex = Assert.Throws<Exception>(() => _plateauMap.SetMap(5, -5));
            Assert.Equal("Negative y Coordinate", ex.Message);
        }
    }
}
