using System;
using System.Linq;
using System.Collections.Generic;
using BattleShips.Models.Ships;
using BattleShips.Services;

namespace BattleShips.Models
{
    class Board : IBoard
    {
        public int Width { private set; get; }
        public int Height { private set; get; }
        public List<IShip> Ships { get; private set; } = new List<IShip>();

        private readonly ShipSetup _shipConfig;
        private readonly IShipPlacement _shipPlacer;

        public Board(IShipPlacement shipPlacer, ShipSetup shipConfig, int width = 5, int height = 5)
        {
            if (width == 0 || height == 0)
            {
                throw new ArgumentException($"Invalid game board dimesnions: {width} x {height}");
            }

            Width = width;
            Height = height;

            _shipConfig = shipConfig;
            _shipPlacer = shipPlacer;
        }

        public void PlaceShips()
        {
            Ships = _shipPlacer.PlaceShips(Width, Height, _shipConfig);
        }

        public IShip ShipHasCoord(int x, int y)
        {
            return Ships.FirstOrDefault(s => s.HasCoord(x, y));
        }

        public bool AllShipsSunk()
        {
            return Ships.All(s => s.ShipSunk());
        }
    }
}
