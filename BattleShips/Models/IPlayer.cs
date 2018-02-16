using BattleShips.Models.Ships;

namespace BattleShips.Models
{
    interface IPlayer
    {
        IShip ShipHasCoord(int x, int y);
        bool AllShipsSunk();
        IBoard Battlefield { get; }
        void PlaceShips();
    }
}
