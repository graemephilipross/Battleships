﻿using System;

namespace BattleShips.Models
{
    class Board : IBoard
    {
        public int Width { private set; get; }
        public int Height { private set; get; }

        public Board(int width = 5, int height = 5)
        {
            if (width == 0 || height == 0)
            {
                throw new ArgumentException($"Invalid game board dimesnions: {width} x {height}");
            }

            Width = width;
            Height = height;
        }
    }
}