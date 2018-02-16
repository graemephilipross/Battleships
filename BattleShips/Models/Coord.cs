namespace BattleShips.Models
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
    }
}
