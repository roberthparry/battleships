namespace BattleShipsService
{
    internal class Cell
    {
        /// <summary>
        /// The ship at the target.
        /// </summary>
        /// <value></value>
        public IShip Ship { get; set; }

        /// <summary>
        /// Status of ship at target (Intact, Damaged)
        /// </summary>
        public CellStatus Status { get; set; }
    }
}