using BattleShips.Models;

namespace BattleShips.Services
{
    interface IInput
    {
        Coord ReadUserInGameInput();
        bool ReadUserTryAgainInput();
    }
}
