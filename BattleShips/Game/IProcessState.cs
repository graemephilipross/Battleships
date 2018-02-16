using BattleShips.Services;

namespace BattleShips.Game
{
    interface IProcessState
    {
        GameState ProcessState();
    }
}
