using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Ships;
using BattleShips.Models.Board;

namespace BattleShips.Models.Player
{
    interface IPlayer
    {
        IShip ShipHasCoord(int x, int y);
        bool AllShipsSunk();
        IBoard Battlefield { get; }
    }
}
