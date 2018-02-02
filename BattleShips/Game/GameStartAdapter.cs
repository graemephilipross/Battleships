using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Game;
using BattleShips.Models.ShipConfig;
using BattleShips.Models.Board;
using BattleShips.Output;
using BattleShips.Models.GameState;

namespace BattleShips.Game
{
    class GameStartAdapter : IProcessState
    {
        private readonly IGameBuilder _gameBuilder;
        private readonly ShipSetup _shipConfig;
        private readonly IBoard _battlefield;
        private readonly IOutput _output;

        public GameStartAdapter(IGameBuilder gameBuilder, ShipSetup shipSetup, IBoard battlefield, IOutput output)
        {
            _gameBuilder = gameBuilder;
            _shipConfig = shipSetup;
            _battlefield = battlefield;
            _output = output;
        }

        public GameState ProcessState(GameState state)
        {
            _gameBuilder.PlaceShips(_battlefield, _shipConfig);
            _output.GameStartMessage();
            return GameState.InPlay;
        }
    }
}
