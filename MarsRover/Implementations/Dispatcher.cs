﻿using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
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

            _plateauMap.AddRover(int.Parse(roverPlacement[0]), int.Parse(roverPlacement[1]), roverPlacement[2]);

            return dispatch;
        }
    }
}
