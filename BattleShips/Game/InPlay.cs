using BattleShips.Services;
using BattleShips.Models;

namespace BattleShips.Game
{
    class InPlay : IProcessState
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IPlayer _player;

        public InPlay(IInput input, IOutput output, IPlayer player)
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
            var ship = _player.ShipHasCoord(coords.X, coords.Y);
            if (ship == null)
            {
                 _output.HitMissMessage();
                return GameState.InPlay;
            }
            ship.SetCoordHit(coords.X, coords.Y);
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
