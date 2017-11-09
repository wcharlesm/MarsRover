using MarsRover.Implementations;
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
        public void MoveRoverHappyPath()
        {
            var (x, y, f) = (2, 2, "N");
            _plateauMap.SetMap(5, 5);
            _plateauMap.AddRover(1, 1, "N");
            _plateauMap.MoveRover("MRML");
            var (x1, y1, f1) = _plateauMap.GetPosition();
            Assert.Equal(x, x1);
            Assert.Equal(y, y1);
            Assert.Equal(f, f1);
        }

        [Fact]
        public void AddRoverHappyPath()
        {
            _plateauMap.SetMap(5, 5);
            _plateauMap.AddRover(1, 1, "N");
        }

        [Fact]
        public void AddRoverBeforeMap()
        {
            Exception ex = Assert.Throws<Exception>(() => _plateauMap.AddRover(1, 1, "N"));
            Assert.Equal("Map Not Set", ex.Message);
        }

        [Fact]
        public void SetMapHappyPath()
        {
            _plateauMap.SetMap(5, 5);
        }

        [Fact]
        public void MapAlreadySet()
        {
            _plateauMap.SetMap(5, 5);
            Exception ex = Assert.Throws<Exception>(() => _plateauMap.SetMap(6, 6));

            Assert.Equal("Map Already Set", ex.Message);
        }

        [Fact]
        public void SetMapNegativeX()
        {
            Exception ex = Assert.Throws<Exception>(() => _plateauMap.SetMap(-5, 5));
            Assert.Equal("Invalid Width", ex.Message);
        }

        [Fact]
        public void SetMapNegativeY()
        {
            Exception ex = Assert.Throws<Exception>(() => _plateauMap.SetMap(5, -5));
            Assert.Equal("Invalid Height", ex.Message);
        }
    }
}
