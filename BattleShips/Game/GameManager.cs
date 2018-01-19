using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Board;
using BattleShips.Models.Ships;
using BattleShips.Models.Coords;

namespace BattleShips.Game
{
    class GameManager : IGameManager
    {
        private enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public void PlaceShips(IBoard battlefield, List<IShip> ships, ICreateCoords coordFactory)
        {
            var usedCoords = new List<ICoord>();
            AddShips(battlefield, ships, usedCoords);
        }

        private void AddShips(IBoard battlefield, List<IShip> ships, List<ICoord> usedCoords)
        {
            // generate random x, y between 0 - width, 0 - length and not in checked list

            // place in checked list

            // check if any ship has x, y, coord, if true - repeat


            // generate random direction

            // check if can place

            //if not - reove all coords aside first and repeat with remaining directions - no directions left, go back to step 1
        }
    }
}
