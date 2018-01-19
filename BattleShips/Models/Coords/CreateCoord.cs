using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models.Coords
{
    class CreateCoord : ICreateCoords
    {
        public ICoord Create(int x = 0, int y = 0)
        {
            return new Coord(x, y);
        }
    }
}
