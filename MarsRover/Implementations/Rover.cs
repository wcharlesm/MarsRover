using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Implementations
{
    public class Rover
    {
        private static readonly Dictionary<char, Dictionary<char, char>> _face =
            new Dictionary<char, Dictionary<char, char>>
            {
                { 'N', new Dictionary<char, char>{ { 'L', 'W' }, { 'R', 'E' } } },
                { 'E', new Dictionary<char, char>{ { 'L', 'N' }, { 'R', 'S' } } },
                { 'S', new Dictionary<char, char>{ { 'L', 'E' }, { 'R', 'W' } } },
                { 'W', new Dictionary<char, char>{ { 'L', 'S' }, { 'R', 'N' } } }
            };

        private static readonly Dictionary<char, (int, int)> _move =
            new Dictionary<char, (int, int)>
            {
                { 'N', (0, 1)},
                { 'E', (1, 0)},
                { 'S', (0, -1)},
                { 'W', (-1, 0)}
            };

        public int Width { get; set; }
        public int Height { get; set; }
        public char Facing { get; set; }
        public Rover Move(char instruction) => 
            instruction == 'M' ? 
                new Rover { Width = Width + _move[Facing].Item1, Height  = Height + _move[Facing].Item2, Facing = Facing } :
                new Rover { Width = Width, Height = Height, Facing = _face[Facing][instruction] };
    }
}
