using System;
using System.Collections.Generic;
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

        private static IDictionary<ShipType, Func<List<ICoord>, IShip>> ShipBuilder = new Dictionary<ShipType, Func<List<ICoord>, IShip>>();

        public List<IShip> _ships = new List<IShip>();

        public int TryShipPlacementCount { set; private get; } = 10;

        static GameManager()
        {
            ShipBuilder.Add(ShipType.Destoryer, c => new Destroyer(c));
            ShipBuilder.Add(ShipType.Cruiser, c => new Cruiser(c));
        }

        public void PlaceShips(IBoard battlefield, ShipConfig shipConfig)
        {
            foreach (var item in shipConfig.Ships)
            {
                for (var i = 0; i <= item.Value.Quantity - 1; i++)
                {
                    var coords = CreateShipCoords(battlefield, item.Value, TryShipPlacementCount);
                    _ships.Add(ShipBuilder[item.Key](coords));
                }
            }
        }

        private List<ICoord> CreateShipCoords(IBoard battlefield, ShipInfo shipInfo, int count)
        {
            // prevent infinite recursion
            if (--count == 0)
            {
                throw new Exception($"Unable to create game board. Cannot place ship of length ${shipInfo.Size} coords");
            }

            var r = new Random();
            var availableDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
            var placedCoords = new List<ICoord>();

            var x = r.Next(0, battlefield.Width);
            var y = r.Next(0, battlefield.Height);

            if (ShipHasCoord(x, y))
            {
                return CreateShipCoords(battlefield, shipInfo, count);
            }

            placedCoords.Add(new Coord(x, y));

            Action tryCreateShip = null;
            tryCreateShip = () =>
            {
                var direction = availableDirections[r.Next(availableDirections.Count)];
                for (var i = 0; i <= shipInfo.Size - 2; i++)
                {
                    var canPlace = false;
                    switch (direction)
                    {
                        case Direction.Left:
                            canPlace = ValidCoord(--x, y, battlefield);
                            break;
                        case Direction.Right:
                            canPlace = ValidCoord(++x, y, battlefield);
                            break;
                        case Direction.Up:
                            canPlace = ValidCoord(x, --y, battlefield);
                            break;
                        case Direction.Down:
                            canPlace = ValidCoord(x, ++y, battlefield);
                            break;
                    }

                    if (canPlace)
                    {
                        placedCoords.Add(new Coord(x, y));
                    }
                    else
                    {
                        availableDirections.Remove(direction);

                        if (!availableDirections.Any())
                        {
                            CreateShipCoords(battlefield, shipInfo, count);
                            break;
                        }

                        placedCoords.RemoveRange(1, placedCoords.Count - 1);
                        x = placedCoords.First().X;
                        y = placedCoords.First().Y;
                        tryCreateShip();
                        break;
                    }
                }
            };
            tryCreateShip();
            return placedCoords;
        }

        private bool ShipHasCoord(int x, int y)
        {
            return _ships.Any(ship => ship.HasCoord(x, y));
        }

        private bool WithinGameBoard(int x, int y, IBoard battlefield)
        {
            return (x >= 0 && x <= battlefield.Width) && (y >= 0 && y <= battlefield.Height);
        }

        private bool ValidCoord(int x, int y, IBoard battlefield)
        {
            return !ShipHasCoord(x, y) && WithinGameBoard(x, y, battlefield);
        }
    }
}
