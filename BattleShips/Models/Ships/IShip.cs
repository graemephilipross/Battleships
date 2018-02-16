﻿using System.Collections.Generic;

namespace BattleShips.Models.Ships
{
    interface IShip
    {
        int Size { get; }
        string Name { get; }
        List<ICoord> Coords { get; }

        bool HasCoord(int x, int y);
        int IntactCoords();
        bool ShipSunk();
        void SetCoordHit(int x, int y);
    }
}
