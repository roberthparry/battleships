using System;
using BattleShipsService;

namespace BattleShipsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Gameboard();
            board.Setup();
            board.Print();
        }
    }
}
