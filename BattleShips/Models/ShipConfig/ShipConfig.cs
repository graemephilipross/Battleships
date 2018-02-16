using System.Collections.Generic;

namespace BattleShips.Models.ShipConfig
{
    public enum ShipType
    {
        Destoryer,
        Cruiser
    }

    struct ShipSetup
    {
        public IDictionary<ShipType, ShipInfo> Ships;
    };

    public class ShipInfo
    {
        public int Size { get; set; }
        public int Quantity { get; set; }
    }
}
