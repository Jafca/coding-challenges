using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Robot
    {
        public List<string> Orientations = new List<string> { "N", "E", "S", "W" };
        
        private int _x;
        private int _y;
        private string _orientation;
        private string _instructions;
        private Arena _battleArena;

        public Robot(Arena arena, string position, string instructions)
        {
            _battleArena = arena;
            var coordinates = position.Split(' ');
            _x = int.Parse(coordinates[0]);
            _y = int.Parse(coordinates[1]);
            _orientation = coordinates[2];
            _instructions = instructions;
        }

        public string FollowInstructions()
        {
            foreach(var instruction in _instructions)
            {
                if (instruction == 'R')
                    TurnRight();
                else if (instruction == 'L')
                    TurnLeft();
                else if (instruction == 'M')
                    Move();
            }
            return $"{_x} {_y} {_orientation}";
        }

        private void TurnRight()
        {
            var idx = Orientations.IndexOf(_orientation);
            idx++;
            idx %= Orientations.Count;
            _orientation = Orientations[idx];
        }

        private void TurnLeft()
        {
            var idx = Orientations.IndexOf(_orientation);
            idx--;
            if (idx < 0)
                idx += Orientations.Count;

            _orientation = Orientations[idx];
        }

        private void Move()
        {
            switch (_orientation)
            {
                case "N":
                    if (_y != _battleArena.Y)
                        _y++;
                    break;
                case "E":
                    if (_x != _battleArena.X)
                        _x++;
                    break;
                case "S":
                    if (_y != 0)
                        _y--;
                    break;
                case "W":
                    if (_x != 0)
                        _x--;
                    break;
            }
        }
    }
}
