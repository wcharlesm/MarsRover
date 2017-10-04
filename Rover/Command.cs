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
            var cmd = CommandFactory.Get(sr.ReadLine());
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
    static class CommandFactory
    {
        public static ICommand Get(string input)
        {
            switch (input)
            {
                case "M":
                    return new MoveCommand();
                case "L":
                case "R":
                    return new TurnCommand(input);
                default:
                    return new NoCommand();
            }
        }
    }
    interface ICommand
    {
        void Execute(Rover.Rover rover);
    }
    public class TurnCommand : ICommand
    {
        public string direction {get; private set;}
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

    public class MoveCommand : ICommand
    {
        public void Execute(Rover.Rover rover)
        {
            rover.Move();
        }
    }
    public class NoCommand : ICommand
    {
        public void Execute(Rover.Rover rover)
        {
            
        }
    }
}