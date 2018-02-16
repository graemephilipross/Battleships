using BattleShips.Input;
using BattleShips.Output;
using BattleShips.Models.Player;
using BattleShips.Models.GameState;

namespace BattleShips.Game
{
    class GameInPlay : IProcessState
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IPlayer _player;

        public GameInPlay(IInput input, IOutput output, IPlayer player)
        {
            _input = input;
            _output = output;
            _player = player;
        }

        public GameState ProcessState()
        {
            return InPlayFacade();
        }

        private GameState InPlayFacade()
        {
            _output.PlayerTurnMessage(_player.Battlefield);
            var coords = _input.ReadUserInGameInput();
            var ship = _player.ShipHasCoord(coords[0], coords[1]);
            if (ship == null)
            {
                 _output.HitMissMessage();
                return GameState.InPlay;
            }
            ship.SetCoordHit(coords[0], coords[1]);
            if (_player.AllShipsSunk())
            {
                _output.GameCompleteMessage();
                return GameState.Complete;
            }
            _output.HitSuccessMessage(ship);
            return GameState.InPlay;
        }
    }
}
