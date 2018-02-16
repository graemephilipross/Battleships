namespace BattleShips.Models
{
    class Cell : Coord, ICell
    {
        public bool IsHit { get; set; }

        public Cell(int x, int y, bool isHit = false) : base(x, y)
        {
            IsHit = isHit;
        }
    }
}
