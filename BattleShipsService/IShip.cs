using System;

namespace BattleShipsService
{
    public interface IShip
    {
        Int16 Length { get; }
        String Name { get; }

        BattleShipType Type { get; }
    }
}
