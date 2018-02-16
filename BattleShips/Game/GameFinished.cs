using BattleShips.Models.GameState;
using BattleShips.Output;
using BattleShips.Input;

namespace BattleShips.Game
{
    class GameFinished : IProcessState
    {
        private readonly IOutput _output;
        private readonly IInput _input;

        public GameFinished(IOutput output, IInput input)
        {
            _output = output;
            _input = input;
        }

        public GameState ProcessState()
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
