using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Implementations
{
    public class PlateauMap : IPlateauMap
    {
        private int _height = 0;
        private int _width = 0;

        public void AddRover(int x, int y, string facing)
        {
            throw new NotImplementedException();
        }

        public (int, int, string) GetPosition()
        {
            throw new NotImplementedException();
        }

        public void MoveRover(string instructions)
        {
            throw new NotImplementedException();
        }

        public void SetMap(int width, int height)
        {
            if (width < 1)
            {
                throw new Exception("Invalid Width");
            }

            if (height < 1)
            {
                throw new Exception("Invalid Height");
            }

            _width = width;
            _height = height;
        }
    }
}
