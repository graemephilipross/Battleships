using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Coords;

namespace BattleShips.Models.Ships
{
    interface IShip
    {
        int Size { get; }
        string Name { get; }
        List<ICoord> Coords { get; }
    }
}
