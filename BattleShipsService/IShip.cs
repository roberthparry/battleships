using System;

namespace BattleShipsService {
    public interface IShip
    {
        /// <summary>
        /// The number of squares the ship occupies.
        /// </summary>
        /// <value></value>
        Int16 Length { get; }
        
        /// <summary>
        /// The name of the type of ship.
        /// </summary>
        String Name { get; }
        
        /// <summary>
        /// The type of the ship.
        /// </summary>
        ShipType Type { get; }

        /// <summary>
        /// Number of hits taken.
        /// </summary>
        Int16 Hits { get; set; }
    }
}