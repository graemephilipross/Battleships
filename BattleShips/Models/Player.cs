using System.Collections.Generic;
using System.Linq;
using BattleShips.Models.Ships;
using BattleShips.Services;

namespace BattleShips.Models
{
    class Player: IPlayer
    {
        public IBoard Battlefield { get; private set; }

        public Player(IBoard battlefield)
        {
            Battlefield = battlefield;
        }

        public void SetUp()
        {
            Battlefield.PlaceShips();
        }

        public IShip Attack(int x, int y)
        {
            return Battlefield.ShipHasCoord(x, y);
        }

        public bool HasWon()
        {
            return Battlefield.AllShipsSunk();
        }
    }
}
