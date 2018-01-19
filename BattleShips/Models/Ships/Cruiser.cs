using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Coords;

namespace BattleShips.Models.Ships
{
    class Cruiser : AbstractShip
    {
        public Cruiser(ICreateCoords coordFactory, int size = 4, string name = "Cruiser")
            : base(coordFactory, size, name)
        {
        }
    }
}
