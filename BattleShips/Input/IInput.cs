using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Input
{
    interface IInput
    {
        int[] ReadUserInGameInput();
        bool ReadUserTryAgainInput();
    }
}
