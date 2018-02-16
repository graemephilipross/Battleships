using BattleShips.Models;

namespace BattleShips.Services
{
    interface IInput
    {
        CoordDTO ReadUserInGameInput();
        bool ReadUserTryAgainInput();
    }
}
