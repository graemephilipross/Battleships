using BattleShips.Models.GameState;

namespace BattleShips.Game
{
    interface IProcessState
    {
        GameState ProcessState();
    }
}
