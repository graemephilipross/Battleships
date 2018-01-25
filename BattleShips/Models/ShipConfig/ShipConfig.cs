using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models.Ships;

namespace BattleShips.Models.ShipConfig
{
    public enum ShipType
    {
        Destoryer,
        Cruiser
    }

    struct ShipConfig
    {
        public IDictionary<ShipType, ShipInfo> Ships;
    };

    public class ShipInfo
    {
        public int Size { get; set; }
        public int Quantity { get; set; }
    }
}
