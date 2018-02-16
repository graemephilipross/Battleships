using System.Collections.Generic;

namespace BattleShips.Models.Ships
{
    class Cruiser : AbstractShip
    {
        public Cruiser(List<ICoord> coords, int size = 4, string name = "Cruiser")
            : base(coords, size, name)
        {
        }
    }
}
