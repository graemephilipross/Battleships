using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Coords;

namespace BattleShips.Models.Ships
{
    class Destroyer : AbstractShip
    {
        public Destroyer(ICreateCoords coordFactory, int size = 5, string name = "Destroyer")
            : base(coordFactory, size, name)
        {
        }
    }
}
