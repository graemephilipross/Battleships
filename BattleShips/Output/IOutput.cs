using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Ships;
using BattleShips.Models.Board;

namespace BattleShips.Output
{
    interface IOutput
    {
        void PlayerTurnMessage(IBoard battlefield);
        void HitSuccessMessage(IShip ship);
        void HitMissMessage();
        void GameCompleteMessage();
        void ErrorMessage(ErrorOutput err);
    }
}
