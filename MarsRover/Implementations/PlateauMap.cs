using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Implementations
{
    public class PlateauMap : IPlateauMap
    {
        private int _height = 0;
        private int _width = 0;
        private (int, int, string) _rover = (0, 0, "");

        private readonly Dictionary<string, Dictionary<char, string>> _face = 
            new Dictionary<string, Dictionary<char, string>>
            {
                { "N", new Dictionary<char, string>{ { 'L', "W" }, { 'R', "E" } } },
                { "E", new Dictionary<char, string>{ { 'L', "N" }, { 'R', "S" } } },
                { "S", new Dictionary<char, string>{ { 'L', "E" }, { 'R', "W" } } },
                { "W", new Dictionary<char, string>{ { 'L', "S" }, { 'R', "N" } } }
            };

        private readonly Dictionary<string, (int, int)> _move =
            new Dictionary<string, (int, int)>
            {
                { "N", (0, 1)},
                { "E", (1, 0)},
                { "S", (0, -1)},
                { "W", (1, 0)}
            };

        public void AddRover(int x, int y, string facing)
        {
            if (_width == 0)
            {
                throw new Exception("Map Not Set");
            }

            _rover = (x, y, facing);
        }

        public (int, int, string) GetPosition()
        {
            return _rover;
        }

        public void MoveRover(string instructions)
        {
            _rover = instructions.ToCharArray()
                .Aggregate(_rover, (rov, instr) => {
                    var (x, y, f) = rov;

                    if (instr == 'M')
                    {
                        var (xd, yd) = _move[f];
                        var (x1, y1) = (x + xd, y + yd);
                        return (Math.Min(Math.Max(x1, 0), _width),
                            Math.Min(Math.Max(y1, 0), _height), f);
                    }
                    else
                    {
                        return (x, y, _face[f][instr]);
                    }
                });
        }

        public void SetMap(int width, int height)
        {
            if (width < 1)
            {
                throw new Exception("Invalid Width");
            }

            if (height < 1)
            {
                throw new Exception("Invalid Height");
            }

            if (_width != 0)
            {
                throw new Exception("Map Already Set");
            }

            _width = width;
            _height = height;
        }
    }
}
