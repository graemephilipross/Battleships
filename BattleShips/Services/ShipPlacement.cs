using System;
using System.Collections.Generic;
using System.Linq;
using BattleShips.Models;
using BattleShips.Models.Ships;

namespace BattleShips.Services
{
    class ShipPlacement : IShipPlacement
    {
        private enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        private readonly static IDictionary<ShipType, Func<List<ICell>, IShip>> ShipBuilder;

        public int TryShipPlacementCount { set; private get; } = 20;

        static ShipPlacement()
        {
            ShipBuilder = new Dictionary<ShipType, Func<List<ICell>, IShip>>();
            ShipBuilder.Add(ShipType.Destoryer, c => new Destroyer(c));
            ShipBuilder.Add(ShipType.Cruiser, c => new Cruiser(c));
        }

        public List<IShip> PlaceShips(IBoard battlefield, ShipSetup shipConfig)
        {
            var ships = new List<IShip>();

            foreach (var item in shipConfig.Ships)
            {
                for (var i = 0; i <= item.Value.Quantity - 1; i++)
                {
                    var coords = CreateShipCoords(ships, battlefield, item.Value).ToList();
                    ships.Add(ShipBuilder[item.Key](coords));
                }
            }

            return ships;
        }

        private IEnumerable<ICell> CreateShipCoords(List<IShip> ships, IBoard battlefield, ShipInfo shipInfo)
        {
            for (var i = 0; i <= TryShipPlacementCount - 1; i++)
            {
                var result = TryPlaceCoords(new List<ICell>(), ships, battlefield, shipInfo);
                if (result.Count() == shipInfo.Size)
                {
                    return result;
                }
            }
            throw new Exception($"Unable to create game board. Cannot place ship of length ${shipInfo.Size} coords");
        }

        private IEnumerable<ICell> TryPlaceCoords(List<ICell> placedCoords, List<IShip> ships, IBoard battlefield, ShipInfo shipInfo)
        {
            var r = new Random();
            var availableDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();

            var x = r.Next(0, battlefield.Width - 1);
            var y = r.Next(0, battlefield.Height - 1);

            if (UsedCoord(x, y, ships))
            {
                return Enumerable.Empty<ICell>();
            }

            placedCoords.Add(new Cell(x, y));

            var initialDirection = GetRandomDirection(r, availableDirections);

            Func<Direction, IEnumerable<ICell>> tryCreateShip = null;
            tryCreateShip = (direction) =>
            {
                for (var i = placedCoords.Count; i <= shipInfo.Size - 1; i++)
                {
                    var canPlace = false;
                    switch (direction)
                    {
                        case Direction.Left:
                            canPlace = ValidCoord(--x, y, battlefield, ships);
                            break;
                        case Direction.Right:
                            canPlace = ValidCoord(++x, y, battlefield, ships);
                            break;
                        case Direction.Up:
                            canPlace = ValidCoord(x, --y, battlefield, ships);
                            break;
                        case Direction.Down:
                            canPlace = ValidCoord(x, ++y, battlefield, ships);
                            break;
                    }

                    if (canPlace)
                    {
                        placedCoords.Add(new Cell(x, y));
                    }
                    else
                    {
                        availableDirections.Remove(direction);

                        if (!availableDirections.Any())
                        {
                            return Enumerable.Empty<ICell>();
                        }

                        var oppositeDirection = GetOppositeDirection(direction);
                        x = placedCoords.First().X;
                        y = placedCoords.First().Y;

                        if (availableDirections.Contains(oppositeDirection))
                        {
                            tryCreateShip(oppositeDirection);
                            break;
                        }

                        placedCoords.RemoveRange(1, placedCoords.Count - 1);
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

        private bool UsedCoord(int x, int y, List<IShip> ships)
        {
            return ships.Any(ship => ship.HasCoord(x, y));
        }

        private bool WithinGameBoard(int x, int y, IBoard battlefield)
        {
            return (x >= 0 && x <= battlefield.Width - 1) && (y >= 0 && y <= battlefield.Height - 1);
        }

        private bool ValidCoord(int x, int y, IBoard battlefield, List<IShip> ships)
        {
            return !UsedCoord(x, y, ships) && WithinGameBoard(x, y, battlefield);
        }
    }
}
