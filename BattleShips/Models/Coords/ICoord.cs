using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models.Coords
{
    interface ICoord
    {
        int X { get; }
        int Y { get; }
        bool IsHit { get; }
    }
}
