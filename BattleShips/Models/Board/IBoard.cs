﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models.Board
{
    interface IBoard
    {
        int[,] Battlefield { get; }
    }
}