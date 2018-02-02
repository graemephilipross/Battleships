using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Board;
using BattleShips.Models.Ships;
using BattleShips.Models.Coords;
using BattleShips.Models.ShipConfig;

namespace BattleShips.Game
{
    interface IGameBuilder
    {
        List<IShip> Ships { get; }
        void PlaceShips(IBoard battlefield, ShipSetup shipConfig);
        IShip ShipHasCoord(int x, int y);
        bool AllShipsSunk();
    }
}
