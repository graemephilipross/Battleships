using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Coords;

namespace BattleShips.Models.Ships
{
    abstract class AbstractShip : IShip
    {
        public int Size { private set; get; }
        public string  Name { private set; get; }
        public List<ICoord> Coords { set; get; }

        public AbstractShip(ICreateCoords coordFactory, int size, string name)
        {
            Size = size;
            Name = name;

            for (var i = 0; i < Size - 1; i++)
            {
                var coord = coordFactory.Create();
                Coords.Add(coord);
            }
        }
    }
}
