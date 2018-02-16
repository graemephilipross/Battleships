using System.Collections.Generic;
using System.Linq;
using BattleShips.Models.Board;
using BattleShips.Models.Ships;
using BattleShips.Models.ShipConfig;
using BattleShips.Services.ShipPlacement;

namespace BattleShips.Models.Player
{
    class Player: IPlayer
    {
        public List<IShip> Ships { get; private set; } = new List<IShip>();
        public IBoard Battlefield { get; private set; }

        private readonly ShipSetup _shipConfig;
        private readonly IShipPlacement _shipPlacer;

        public Player(IShipPlacement shipPlacer, IBoard battlefield, ShipSetup shipConfig)
        {
            Battlefield = battlefield;
            _shipConfig = shipConfig;
            _shipPlacer = shipPlacer;
        }

        public void PlaceShips()
        {
            Ships = _shipPlacer.PlaceShips(Battlefield, _shipConfig);
        }

        public IShip ShipHasCoord(int x, int y)
        {
            return Ships.FirstOrDefault(s => s.HasCoord(x, y));
        }

        public bool AllShipsSunk()
        {
            return Ships.All(s => s.ShipSunk());
        }
    }
}
