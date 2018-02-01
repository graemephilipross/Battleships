using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BattleShips.Models.Coords;

namespace BattleShips.Models.Ships
{
    abstract class AbstractShip : IShip
    {
        public int Size { private set; get; }
        public string  Name { private set; get; }
        public List<ICoord> Coords { set; get; }

        public AbstractShip(List<ICoord> coords, int size, string name)
        {
            Size = size;
            Name = name;
            Coords = coords;
        }

        public bool HasCoord(int x, int y)
        {
            return Coords.Any(coord => coord.X == x && coord.Y == y);
        }

        public bool ShipSunk()
        {
            return Coords.All(coord => coord.IsHit);
        }

        public int IntactCoords()
        {
            return Coords.Count(coord => !coord.IsHit);
        }

        public void SetCoordHit(int x, int y)
        {
            var c = Coords.FirstOrDefault(coord => coord.X == x && coord.Y == y);
            if (c != null)
            {
                c.IsHit = true;
            }
        }
    }
}
