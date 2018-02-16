using BattleShips.Services;

namespace BattleShips.Game
{
    class Complete : IProcessState
    {
        private readonly IOutput _output;
        private readonly IInput _input;

        public Complete(IOutput output, IInput input)
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
