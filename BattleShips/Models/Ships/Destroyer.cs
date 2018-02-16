using System.Collections.Generic;
using BattleShips.Models.Coords;

namespace BattleShips.Models.Ships
{
    class Destroyer : AbstractShip
    {
        public Destroyer(List<ICoord> coords, int size = 5, string name = "Destroyer")
            : base(coords, size, name)
        {
        }
    }
}
