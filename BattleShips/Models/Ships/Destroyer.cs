using System.Collections.Generic;

namespace BattleShips.Models.Ships
{
    class Destroyer : AbstractShip
    {
        public Destroyer(List<ICell> coords, int size = 5, string name = "Destroyer")
            : base(coords, size, name)
        {
        }
    }
}
