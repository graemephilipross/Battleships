using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Game;
using BattleShips.Models.ShipConfig;
using BattleShips.Models.Board;
using BattleShips.Output;
using BattleShips.Models.GameState;
using BattleShips.Models.Player;

namespace BattleShips.Game
{
    class GameStart : IProcessState
    {
        private readonly IOutput _output;

        public GameStart(IOutput output)
        {
            _output = output;
        }

        public GameState ProcessState()
        {
            _output.GameStartMessage();
            return GameState.InPlay;
        }
    }
}
