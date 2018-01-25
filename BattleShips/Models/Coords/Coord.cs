using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models.Coords
{
    class Coord : ICoord
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsHit { get; set; }

        public Coord(int x, int y, bool isHit = false)
        {
            X = x;
            Y = y;
            IsHit = isHit;
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //    {
        //        return false;
        //    }

        //    var c = (ICoord)obj;
        //    return (X == c.X) && (Y == c.Y) && (IsHit == c.IsHit);
        //}
    }
}
