using System;
using System.Collections.Generic;
using System.Linq;
using BattleShips.Models.Board;
using BattleShips.Models.Ships;
using BattleShips.Models.Coords;
using BattleShips.Models.ShipConfig;

namespace BattleShips.Game
{
    class GameBuilder : IGameBuilder
    {
        private enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        private readonly static IDictionary<ShipType, Func<List<ICoord>, IShip>> ShipBuilder;

        public List<IShip> Ships { get; private set; } = new List<IShip>();

        public int TryShipPlacementCount { set; private get; } = 20;

        static GameBuilder()
        {
            ShipBuilder = new Dictionary<ShipType, Func<List<ICoord>, IShip>>();
            ShipBuilder.Add(ShipType.Destoryer, c => new Destroyer(c));
            ShipBuilder.Add(ShipType.Cruiser, c => new Cruiser(c));
        }

        public IShip ShipHasCoord(int x, int y)
        {
            return Ships.FirstOrDefault(s => s.HasCoord(x, y));
        }

        public bool AllShipsSunk()
        {
            return Ships.All(s => s.ShipSunk());
        }

        public void PlaceShips(IBoard battlefield, ShipSetup shipConfig)
        {
            foreach (var item in shipConfig.Ships)
            {
                for (var i = 0; i <= item.Value.Quantity - 1; i++)
                {
                    var coords = CreateShipCoords(battlefield, item.Value).ToList();
                    Ships.Add(ShipBuilder[item.Key](coords));
                }
            }
        }

        private IEnumerable<ICoord> CreateShipCoords(IBoard battlefield, ShipInfo shipInfo)
        {
            for (var i = 0; i <= TryShipPlacementCount - 1; i++)
            {
                var result = TryPlaceCoords(new List<ICoord>(), battlefield, shipInfo);
                if (result.Count() == shipInfo.Size)
                {
                    return result;
                }
            }
            throw new Exception($"Unable to create game board. Cannot place ship of length ${shipInfo.Size} coords");
        }

        private IEnumerable<ICoord> TryPlaceCoords(List<ICoord> placedCoords, IBoard battlefield, ShipInfo shipInfo)
        {
            var r = new Random();
            var availableDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();

            var x = r.Next(0, battlefield.Width - 1);
            var y = r.Next(0, battlefield.Height - 1);

            if (UsedCoord(x, y))
            {
                return Enumerable.Empty<ICoord>();
            }

            placedCoords.Add(new Coord(x, y));

            var initialDirection = GetRandomDirection(r, availableDirections);

            Func<Direction, IEnumerable<ICoord>> tryCreateShip = null;
            tryCreateShip = (direction) =>
            {
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
                            return Enumerable.Empty<ICoord>();
                        }

                        var oppositeDirection = GetOppositeDirection(direction);
                        placedCoords.RemoveRange(1, placedCoords.Count - 1);
                        x = placedCoords.First().X;
                        y = placedCoords.First().Y;

                        if (availableDirections.Contains(oppositeDirection))
                        {
                            tryCreateShip(oppositeDirection);
                            break;
                        }

                        tryCreateShip(GetRandomDirection(r, availableDirections));
                        break;
                    }
                }
                return placedCoords;
            };
            return tryCreateShip(initialDirection);
        }

        private Direction GetRandomDirection(Random r, List<Direction> directions)
        {
            return directions[r.Next(directions.Count)];
        }

        private Direction GetOppositeDirection(Direction direction)
        {
            Direction oppositeDirection = direction;
            switch (direction)
            {
                case Direction.Left:
                    oppositeDirection = Direction.Right;
                    break;
                case Direction.Right:
                    oppositeDirection = Direction.Left;
                    break;
                case Direction.Up:
                    oppositeDirection = Direction.Down;
                    break;
                case Direction.Down:
                    oppositeDirection = Direction.Up;
                    break;
            }
            return oppositeDirection;
        }

        private bool UsedCoord(int x, int y)
        {
            return Ships.Any(ship => ship.HasCoord(x, y));
        }

        private bool WithinGameBoard(int x, int y, IBoard battlefield)
        {
            return (x >= 0 && x <= battlefield.Width - 1) && (y >= 0 && y <= battlefield.Height - 1);
        }

        private bool ValidCoord(int x, int y, IBoard battlefield)
        {
            return !UsedCoord(x, y) && WithinGameBoard(x, y, battlefield);
        }
    }
}
