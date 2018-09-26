using System;

namespace BattleShipsService
{
    public class Destroyer : Ship
    {
        /// <summary>
        /// The number of squares the ship occupies.
        /// </summary>
        public override Int16 Length => 4;

        /// <summary>
        /// The name of the type of ship.
        /// </summary>
        public override String Name => $"{nameof(Destroyer)}";

        /// <summary>
        /// The type of the ship.
        /// </summary>
        public override ShipType Type => ShipType.Destroyer;
    }
}
