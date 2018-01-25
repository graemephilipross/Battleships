using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Board;
using BattleShips.Models.Ships;
using BattleShips.Models.Coords;
using BattleShips.Models.ShipConfig;

namespace BattleShips.Game
{
    interface IGameManager
    {
        void PlaceShips(IBoard battlefield, ShipConfig shipConfig);
    }
}
