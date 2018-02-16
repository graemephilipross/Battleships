using BattleShips.Services;
using BattleShips.Models;

namespace BattleShips.Game
{
    class Start : IProcessState
    {
        private readonly IOutput _output;
        private readonly IPlayer _player;

        public Start(IOutput output, IPlayer player)
        {
            _output = output;
            _player = player;
        }

        public GameState ProcessState()
        {
            _player.SetUp();
            _output.GameStartMessage();
            return GameState.InPlay;
        }
    }
}
