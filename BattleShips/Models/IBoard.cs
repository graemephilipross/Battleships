using BattleShips.Models.Ships;
using System.Collections.Generic;

namespace BattleShips.Models
{
    interface IBoard
    {
        int Width { get; }
        int Height { get; }
        List<IShip> Ships { get; }

        void PlaceShips();
        IShip ShipHasCoord(int x, int y);
        bool AllShipsSunk();
    }
}
