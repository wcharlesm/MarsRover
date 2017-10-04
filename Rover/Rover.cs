using System;
using System.Collections.Generic;
using System.IO;

namespace Rover
{
    public enum Direction{
        NORTH,SOUTH,EAST,WEST
    }
    public class Rover
    {
        public Direction direction{get; private set;}
        public Rover(Direction startDirection){
            direction = startDirection;
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
        public void TurnLeft()
        {
            direction = Turns().Find(direction).Next.Value;
        }

        public void TurnRight()
        {
            direction = Turns().FindLast(direction).Previous.Value;
        }
    }
}