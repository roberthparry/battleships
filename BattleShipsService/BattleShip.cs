using System;

namespace BattleShipsService
{
    public class BattleShip : IShip
    {    
        /// <summary>
        /// The number of squares the ship occupies.
        /// </summary>
        public Int16 Length => 5;

        /// <summary>
        /// The name of the type of ship.
        /// </summary>
        public String Name => $"{nameof(BattleShip)}";

        /// <summary>
        /// The type of the ship.
        /// </summary>
        public ShipType Type => ShipType.BattleShip;

    }
}
