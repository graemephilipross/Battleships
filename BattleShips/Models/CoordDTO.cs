using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    class CoordDTO
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CoordDTO(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
