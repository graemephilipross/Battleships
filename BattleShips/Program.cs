using System;
using System.Linq;
using System.Collections.Generic;
using BattleShips.Models.Board;
using BattleShips.Models.Ships;
using BattleShips.Models.Coords;
using BattleShips.Models.ShipConfig;
using BattleShips.Game;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            var destroyerInfo = new ShipInfo()
            {
                Size = 4,
                Quantity = 2
            };

            var cruiserInfo = new ShipInfo()
            {
                Size = 3,
                Quantity = 2
            };

            var shipConfig = new ShipSetup();
            shipConfig.Ships = new Dictionary<ShipType, ShipInfo>()
            {
                { ShipType.Destoryer, destroyerInfo },
                { ShipType.Cruiser, cruiserInfo }
            };

            var board = new Board(5, 5);

            var gameBuilder = new GameBuilder();
            gameBuilder.PlaceShips(board, shipConfig);
        }
    }
}
