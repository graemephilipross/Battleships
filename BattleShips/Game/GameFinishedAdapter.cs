using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.GameState;
using BattleShips.Output;
using BattleShips.Input;

namespace BattleShips.Game
{
    class GameFinishedAdapter : IProcessState
    {
        private readonly IOutput _output;
        private readonly IInput _input;

        public GameFinishedAdapter(IOutput output, IInput input)
        {
            _output = output;
            _input = input;
        }

        public GameState ProcessState(GameState state)
        {
            _output.PlayAgainMessage();
            var playAgain = _input.ReadUserTryAgainInput();
            if (playAgain)
            {
                return GameState.Setup;
            }
            return GameState.Quit;
        }
    }
}
