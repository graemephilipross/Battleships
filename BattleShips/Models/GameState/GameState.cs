using System;
using BattleShips.Game;

namespace BattleShips.Models.GameState
{
    public enum GameState
    {
        Setup,
        InPlay,
        Complete,
        Quit
    }

    class GameStateManager
    {
        private Func<GameState, IProcessState> _lookup;

        public GameStateManager(Func<GameState, IProcessState> lookup)
        {
            _lookup = lookup;
        }

        public GameState Process(GameState state)
        {
            return _lookup(state)?.ProcessState() ?? GameState.Quit;
        }
    }
}
