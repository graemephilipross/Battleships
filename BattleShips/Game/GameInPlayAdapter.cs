using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.GameState;

namespace BattleShips.Game
{
    class GameInPlayAdapter : IProcessState
    {
        private readonly IGameInPlay _gameInPlay;

        public GameInPlayAdapter(IGameInPlay gameInPlay)
        {
            _gameInPlay = gameInPlay;
        }

        public GameState ProcessState(GameState state)
        {
           return _gameInPlay.InPlayFacade(state);
        }
    }
}
