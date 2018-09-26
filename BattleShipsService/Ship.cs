using System;

namespace BattleShipsService {
    public abstract class Ship
    {
        /// <summary>
        /// The number of squares the ship occupies.
        /// </summary>
        /// <value></value>
        public virtual Int16 Length { get; }
        
        /// <summary>
        /// The name of the type of ship.
        /// </summary>
        public virtual String Name { get; }
        
        /// <summary>
        /// The type of the ship.
        /// </summary>
        public virtual ShipType Type { get; }

        /// <summary>
        /// Number of hits taken.
        /// </summary>
        public Int16 Hits { get; set; }

        /// <summary>
        /// Determine if the ship is destroyed
        /// </summary>
        public Boolean IsDestroyed => Hits == Length;
    }
}