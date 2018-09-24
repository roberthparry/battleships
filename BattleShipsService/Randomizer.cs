using System;

namespace BattleShipsService
{
    public static class Randomizer
    {
        private static readonly Random _random = new Random();

        public static Direction Orientation => (Direction)_random.Next(2);

        public static Int32 Position(Int16 length) => _random.Next(Gameboard.GridSize - length + 1);
    }
}
