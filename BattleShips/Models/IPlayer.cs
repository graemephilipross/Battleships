using BattleShips.Models.Ships;

namespace BattleShips.Models
{
    interface IPlayer
    {
        IBoard Battlefield { get; }
        void SetUp();
        IShip Attack(int x, int y);
        bool HasWon();
    }
}
