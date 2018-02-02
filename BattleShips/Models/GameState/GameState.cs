using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models.GameState
{
    public enum GameState
    {
        Setup,
        InPlay,
        Complete,
        Quit
    }

    struct GameStateManager
    {
        public IDictionary<GameState, IProcessState> StateManager;
    };
}
