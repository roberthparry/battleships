namespace BattleShipsService
{
    internal class Cell
    {
        /// <summary>
        /// The ship at the cell.
        /// </summary>
        /// <value></value>
        public Ship Ship { get; set; }

        /// <summary>
        /// Status of ship at cell (Intact, Damaged)
        /// </summary>
        public CellStatus Status { get; set; }
    }
}