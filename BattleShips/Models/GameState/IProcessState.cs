using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models.GameState
{
    interface IProcessState
    {
        GameState ProcessState(GameState currentState);
    }
}
