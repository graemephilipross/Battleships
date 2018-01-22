using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BattleShips.Models.Board;
using BattleShips.Models.Ships;
using BattleShips.Models.Coords;
using BattleShips.Models.ShipConfig;

namespace BattleShips.Game
{
    class GameManager : IGameManager
    {
        private enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        private List<IShip> _ships = new List<IShip>();

        public void PlaceShips(IBoard battlefield, ShipConfig shipConfig, ICreateCoords coordFactory)
        {
            foreach(var item in shipConfig.Ships)
            {
                for (var i = 0; i < item.Value.Quantity - 1; i++)
                {
                    var coords = CreateShipCoords(battlefield, item.Value);
                    _ships.Add((IShip)Activator.CreateInstance(Type.GetType(item.Key.ToString())));
                }
            }
        }

        private List<ICoord> CreateShipCoords(IBoard battlefield, ShipInfo shipInfo)
        {
            // need to prevernt infitne recursion

            Random r = new Random();
            var availableDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
            var placedCoords = new List<ICoord>();

            var x = r.Next(0, battlefield.Width);
            var y = r.Next(0, battlefield.Height);

            if (ShipHasCoord(x, y))
            {
                return CreateShipCoords(battlefield, shipInfo);
            }

            placedCoords.Add(new Coord(x, y));

            var direction = availableDirections[r.Next(availableDirections.Count)];

            for (var i = 0; i < shipInfo.Size - 2; i++)
            {
                var canPlace = false;
                switch (direction)
                {
                    case Direction.Left:
                        canPlace = ShipHasCoord(--x, y);
                        break;
                    case Direction.Right:
                        canPlace = ShipHasCoord(++x, y);
                        break;
                    case Direction.Up:
                        canPlace = ShipHasCoord(x, --y);
                        break;
                    case Direction.Down:
                        canPlace = ShipHasCoord(x, ++y);
                        break;
                }

                if (canPlace)
                {
                    placedCoords.Add(new Coord(x, y));
                    continue;
                }

                // if not - 
                // place coord in opposite direction in same plane

                // if not - remove this as opposite direction

                // remove all coords aside first and repeat with remaining directions - no directions left, go back to step 1
            }

            return placedCoords;
        }

        private bool ShipHasCoord(int x, int y)
        {
            return _ships.Any(ship => ship.HasCoord(x, y));
        }
    }
}
