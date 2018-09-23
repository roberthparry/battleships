using System;

namespace BattleShipsService {
    public interface IShip {
        /// <summary>
        /// The number of squares the ship occupies.
        /// </summary>
        /// <value></value>
        Int16 Length { get; }
        
        /// <summary>
        /// The name of the type of ship.
        /// </summary>
        /// <value></value>
        String Name { get; }
        
        /// <summary>
        /// The type of the ship.
        /// </summary>
        /// <value></value>
        ShipType Type { get; }
    }
}