using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models.Board
{
    class Board : IBoard
    {
        public int Width { private set; get; }
        public int Height { private set; get; }

        public Board(int width = 2, int height = 2)
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
