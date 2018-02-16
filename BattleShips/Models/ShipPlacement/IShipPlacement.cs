using System.Collections.Generic;
using BattleShips.Models.Board;
using BattleShips.Models.Ships;
using BattleShips.Models.ShipConfig;

namespace BattleShips.Models.ShipPlacement
{
    interface IShipPlacement
    {
        List<IShip> PlaceShips(IBoard battlefield, ShipSetup shipConfig);
    }
}
