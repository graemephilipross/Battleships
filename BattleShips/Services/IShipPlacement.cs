using System.Collections.Generic;
using BattleShips.Models;
using BattleShips.Models.Ships;

namespace BattleShips.Services
{
    interface IShipPlacement
    {
        List<IShip> PlaceShips(IBoard battlefield, ShipSetup shipConfig);
    }
}
