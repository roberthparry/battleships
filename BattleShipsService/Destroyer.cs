using System;

namespace BattleShipsService
{
    public class Destroyer : IShip
    {
        /// <summary>
        /// The number of squares the ship occupies.
        /// </summary>
        public Int16 Length => 4;

        /// <summary>
        /// The name of the type of ship.
        /// </summary>
        public String Name => $"{nameof(Destroyer)}";

        /// <summary>
        /// The type of the ship.
        /// </summary>
        public ShipType Type => ShipType.Destroyer;

        /// <summary>
        /// The number of hits the ship has taken
        /// </summary>
        public short Hits { get; set; }
    }
}
