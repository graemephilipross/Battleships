using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Input;
using BattleShips.Output;
using BattleShips.Models.Board;
using BattleShips.Models.GameState;

namespace BattleShips.Game
{
    class GameInPlay : IGameInPlay
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IBoard _battlefield;
        private readonly IGameBuilder _gameBuilder;

        public GameInPlay(IInput input, IOutput output, IBoard battlefield, IGameBuilder gameBuilder)
        {
            _input = input;
            _output = output;
            _battlefield = battlefield;
            _gameBuilder = gameBuilder;
        }

        public GameState InPlayFacade(GameState state)
        {
            _output.PlayerTurnMessage(_battlefield);
            var coords = _input.ReadUserInGameInput();
            var ship = _gameBuilder.ShipHasCoord(coords[0], coords[1]);
            if (ship == null)
            {
                 _output.HitMissMessage();
                return state;
            }
            ship.SetCoordHit(coords[0], coords[1]);
            if (_gameBuilder.AllShipsSunk())
            {
                _output.GameCompleteMessage();
                state = GameState.Complete;
                return state;
            }
            _output.HitSuccessMessage(ship);
            return state;
        }
    }
}
