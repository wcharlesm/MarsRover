using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

using Rover;

namespace Rover
{
    [TestFixture]
    public class RoverTest
    {
        [Test]
        [Category("Step2")]
        public void RoverLeft()
        {
            var rover = new Rover(Direction.NORTH);
            rover.TurnLeft();
            rover.direction.Should().Be(Direction.WEST);

            rover = new Rover(Direction.SOUTH);
            rover.TurnLeft();
            rover.direction.Should().Be(Direction.EAST);
        }
        [Test]
        [Category("Step2")]
        public void RoverRight()
        {
            var rover = new Rover(Direction.NORTH);
            rover.TurnRight();
            rover.direction.Should().Be(Direction.EAST);
            
            rover = new Rover(Direction.SOUTH);
            rover.TurnRight();
            rover.direction.Should().Be(Direction.WEST);
        }

        [Test]
        [Category("Step3")]
        public void RoverMove()
        {
            var rover = new Rover(new Position(0,0), Direction.NORTH);
            rover.Move();
            rover.direction.Should().Be(Direction.NORTH);
            rover.position.ShouldBeEquivalentTo(new Position(0,1));
            
            rover = new Rover(Direction.SOUTH);
            rover.TurnRight();
            rover.direction.Should().Be(Direction.WEST);
        }

    }

}