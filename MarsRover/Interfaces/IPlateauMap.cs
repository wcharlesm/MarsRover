using MarsRover.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interfaces
{
    public interface IPlateauMap
    {
        void SetMap(int width, int height);
        void AddRover(Rover rover);
        void MoveRover(string instructions);
        (int, int, char) GetPosition();
    }
}
