using System.Collections.Generic;
using BattleShips.Models;
using BattleShips.Models.Ships;

namespace BattleShips.Services
{
    interface IShipPlacement
    {
        List<IShip> PlaceShips(int width, int height, ShipSetup shipConfig);
    }
}
