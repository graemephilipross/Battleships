using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.GameState;

namespace BattleShips.Game
{
    interface IProcessState
    {
        GameState ProcessState();
    }
}
