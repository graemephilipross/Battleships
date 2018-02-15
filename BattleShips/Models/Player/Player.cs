using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BattleShips.Models.Board;
using BattleShips.Models.Ships;
using BattleShips.Models.ShipConfig;
using BattleShips.Models.ShipPlacement;

namespace BattleShips.Models.Player
{
    class Player: IPlayer
    {
        public List<IShip> _ships { get; private set; } = new List<IShip>();
        public IBoard Battlefield { get; private set; }

        public Player(IShipPlacement shipPlacer, IBoard battlefield, ShipSetup shipConfig)
        {
            _ships = shipPlacer.PlaceShips(battlefield, shipConfig);
            Battlefield = battlefield;
        }

        public IShip ShipHasCoord(int x, int y)
        {
            return _ships.FirstOrDefault(s => s.HasCoord(x, y));
        }

        public bool AllShipsSunk()
        {
            return _ships.All(s => s.ShipSunk());
        }
    }
}
