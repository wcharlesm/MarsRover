using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interfaces
{
    public interface IPlateauMap
    {
        void SetMap(int width, int height);
        void AddRover(int x, int y, String facing);
    }
}
