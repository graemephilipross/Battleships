﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models.Board
{
    class Board : IBoard
    {
        public int[,] Battlefield { private set; get; }

        public Board(int width = 10, int height = 10)
        {
            if (width == 0 || height == 0)
            {
                throw new ArgumentException($"Invalid game board dimesnions: {width} x {height}");
            }

            Battlefield = new int[width, height];
        }
    }
}
