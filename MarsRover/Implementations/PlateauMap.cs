using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Implementations
{
    public class PlateauMap : IPlateauMap
    {
        private int _height = 0;
        private int _width = 0;
        private Rover _rover;

        public void AddRover(Rover rover)
        {
            if (_width == 0)
            {
                throw new Exception("Map Not Set");
            }

            _rover = rover;
        }

        public (int, int, char) GetPosition()
        {
            return (_rover.Width, _rover.Height, _rover.Facing);
        }

        public void MoveRover(string instructions)
        {
            bool InBounds(Rover rov) => 
                rov.Width >= 0 && rov.Width <= _width && rov.Height >= 0 && rov.Height <= _height;
            
            _rover = instructions.ToCharArray()
                .Aggregate(_rover, (rov, instr) => InBounds(rov.Move(instr)) ? rov.Move(instr) : rov);
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

            if (_width != 0)
            {
                throw new Exception("Map Already Set");
            }

            _width = width;
            _height = height;
        }
    }
}
