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
            var start = parseStart(sr.ReadLine());
            var cmd = new TurnCommand(sr.ReadLine());
            var rover = new Rover.Rover(start.Item1, start.Item2);
            cmd.Execute(rover);
            var directionChar = DirectionCommands()
                .FirstOrDefault(x => x.Value.Equals(rover.direction))
                .Key;
            return $"{rover.position.X} {rover.position.Y} {directionChar}";
        }
        private Tuple<Position, Direction> parseStart(string input)
        {
            var inputs = input.Split(' ');
            var pos = new Position(Int16.Parse(inputs[0]), Int16.Parse(inputs[1]));
            var dir =  DirectionCommands()[inputs[2]];
            return new Tuple<Position, Direction>(pos, dir);
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