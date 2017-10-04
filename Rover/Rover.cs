using System;
using System.Collections.Generic;
using System.IO;

namespace Rover
{
    public enum Direction{
        NORTH,SOUTH,EAST,WEST
    }
    public class Position
    {
        public Position(int startX, int startY){
            X = startX;
            Y = startY;
        }
        public int X {get; private set;}
        public int Y {get; private set;}
    }

    public class Rover
    {
        public Direction direction{get; private set;}
        public Position position{get; private set;}
        public Rover(Position startPosition, Direction startDirection)
        {
            position = startPosition;
            direction = startDirection;
        }
        public Rover(Direction startDirection):this(new Position(0,0), startDirection)
        {
            Console.WriteLine("Rover(Direction startDirection) is depricated");
        }
        private LinkedList<Direction> Turns()
        {
            var turns = new LinkedList<Direction>();
            turns.AddLast(Direction.NORTH);
            turns.AddLast(Direction.WEST);
            turns.AddLast(Direction.SOUTH);
            turns.AddLast(Direction.EAST);
            turns.AddLast(Direction.NORTH);
            return turns;
        }
        private Dictionary<Direction, Position> Movements()
        {
            var movements = new Dictionary<Direction, Position>();
            movements.Add(Direction.NORTH, new Position(0, 1));
            movements.Add(Direction.EAST, new Position(1, 0));
            movements.Add(Direction.SOUTH, new Position(0, -1));
            movements.Add(Direction.WEST, new Position(-1, 0));
            return movements;

        }
        public void TurnLeft()
        {
            direction = Turns().Find(direction).Next.Value;
        }

        public void TurnRight()
        {
            direction = Turns().FindLast(direction).Previous.Value;
        }
        public void Move()
        {
            var delta = Movements()[direction];
            position = new Position(position.X + delta.X, position.Y + delta.Y);
        }
    }
}