using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models.Coords
{
    interface ICoord
    {
        int X { get; set; }
        int Y { get; set; }
        bool IsHit { get; set; }
    }
}
