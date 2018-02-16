using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
