using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Rover;

namespace Command
{
    public class MarsRover
    {
        public string Run(string input)
        {
            var sr = new StringReader(input);
            _ = sr.ReadLine();
            var faceing = parseDirection(sr.ReadLine());
            var cmd = new TurnCommand(sr.ReadLine());
            var rover = new Rover.Rover(faceing);
            cmd.Execute(rover);
            var directionChar = DirectionCommands()
                .FirstOrDefault(x => x.Value.Equals(rover.direction))
                .Key;
            return $"1 1 {directionChar}";
        }
        private Direction parseDirection(string input)
        {
            var dirChar = input.Split(' ')[2];
            return DirectionCommands()[dirChar];
        }
        private Dictionary<string, Direction> DirectionCommands(){
            Dictionary<string, Direction> dictionary = new Dictionary<string, Direction>();
            dictionary.Add("N", Direction.NORTH);
            dictionary.Add("E", Direction.EAST);
            dictionary.Add("S", Direction.SOUTH);
            dictionary.Add("W", Direction.WEST);
            return dictionary;
        }
    }
    public class TurnCommand
    {
        private string direction;
        public TurnCommand(string turnDirection)
        {
            direction = turnDirection;
        }

        public void Execute(Rover.Rover rover)
        {
            switch (direction){
                case "L": {
                    rover.TurnLeft();
                    break;
                }
                case "R": {
                    rover.TurnRight();
                    break;                    
                }
            }
        }
    }
}