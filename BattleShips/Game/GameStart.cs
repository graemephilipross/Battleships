using BattleShips.Output;
using BattleShips.Models.GameState;
using BattleShips.Models.Player;

namespace BattleShips.Game
{
    class GameStart : IProcessState
    {
        private readonly IOutput _output;
        private readonly IPlayer _player;

        public GameStart(IOutput output, IPlayer player)
        {
            _output = output;
            _player = player;
        }

        public GameState ProcessState()
        {
            _player.PlaceShips();
            _output.GameStartMessage();
            return GameState.InPlay;
        }
    }
}
