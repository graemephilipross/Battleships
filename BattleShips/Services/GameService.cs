using System;
using BattleShips.Game;

namespace BattleShips.Services
{
    public enum GameState
    {
        Setup,
        InPlay,
        Complete,
        Quit
    }

    class GameService
    {
        private GameState _state;
        private readonly Func<GameState, IProcessState> _lookup;
        private readonly IOutput _output;

        public GameService(Func<GameState, IProcessState> lookup, IOutput output)
        {
            _state = GameState.Setup;
            _lookup = lookup;
            _output = output;
        }

        public void Play()
        {
            if (_state == GameState.Quit)
            {
                return;
            }

            try
            {
                _state = _lookup(_state)?.ProcessState() ?? GameState.Quit;
            }
            catch(Exception e)
            {
                var err = new ErrorOutput();
                err.Message = e.Message;
                _output.ErrorMessage(err);
            }
            finally
            {
                Play();
            }
        }
    }
}
