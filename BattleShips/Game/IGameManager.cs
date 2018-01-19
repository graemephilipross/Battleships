using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Board;
using BattleShips.Models.Ships;
using BattleShips.Models.Coords;

namespace BattleShips.Game
{
    interface IGameManager
    {
        void PlaceShips(IBoard battlefield, List<IShip> ships, ICreateCoords coordFactory);
    }
}
