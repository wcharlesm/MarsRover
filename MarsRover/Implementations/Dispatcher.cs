using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Implementations
{
    public class Dispatcher : IDispatcher
    {
        private IPlateauMap _plateauMap;
        public Dispatcher(IPlateauMap plateauMap)
        {
            _plateauMap = plateauMap;
        }

        public string ReceiveInstructions(string dispatch)
        {
            var instructions = dispatch.Split('\n');

            var plateauCoordinates = instructions[0].Split(' ');

            _plateauMap.SetMap(int.Parse(plateauCoordinates[0]), int.Parse(plateauCoordinates[1]));

            var roverPlacement = instructions[1].Split(' ');

            var rover = new Rover
            {
                Width = int.Parse(roverPlacement[0]),
                Height = int.Parse(roverPlacement[1]),
                Facing = roverPlacement[2].ToCharArray()[0]
            };
            _plateauMap.AddRover(rover);

            _plateauMap.MoveRover(instructions[2]);

            var (x, y, facing) = _plateauMap.GetPosition();

            return $"{x.ToString()} {y.ToString()} {facing}";
        }
    }
}
