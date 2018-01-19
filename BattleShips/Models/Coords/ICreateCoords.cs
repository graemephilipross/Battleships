using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models.Coords
{
    interface ICreateCoords
    {
        ICoord Create(int x = 0, int y = 0);
    }
}
