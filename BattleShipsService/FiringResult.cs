namespace BattleShipsService
{
    public enum FiringResult
    {
        /// <summary>
        /// Didn't hit anything.
        /// </summary>
        Missed = 0,

        /// <summary>
        /// Hit something.
        /// </summary>
        Hit = 1,

        /// <summary>
        /// Location already hit.
        /// </summary>
        Repeat = 2,
    }
}
