﻿using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.GameState;
using BattleShips.Output;

namespace BattleShips.Game
{
    class GameManager
    {
        private GameState _state;
        private readonly GameStateManager _gsm;
        private readonly IOutput _output;

        public GameManager(GameStateManager gsm, IOutput output)
        {
            _state = GameState.Setup;
            _gsm = gsm;
            _output = output;
        }

        public void GameDriver()
        {
            try
            {
                if (_state == GameState.Quit)
                {
                    return;
                }

                if (_gsm.StateManager.ContainsKey(_state))
                {
                    _state = _gsm.StateManager[_state].ProcessState(_state);
                }
                else
                {
                    _state = GameState.Quit;
                }
            }
            catch(Exception e)
            {
                var err = new ErrorOutput();
                err.Message = e.Message;
                _output.ErrorMessage(err);
            }
            finally
            {
                GameDriver();
            }
        }
    }
}
