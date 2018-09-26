using System;
using BattleShipsService;

namespace BattleShipsConsole
{
    class Program
    {
        static void Main()
        {
            var board = new Gameboard();
            board.Setup();
            do {
                board.Print();
                Console.Write("Enter cell to fire at (e.g. A1, B1, ...) or q to quit: ");
                String cellReference = Console.ReadLine();
                if (cellReference.ToLower() == "q") {
                    Console.WriteLine("Bye!");
                    return;
                }

                if (!Gameboard.TranslateCellReference(cellReference, out Int16 row, out Int16 column))
                {
                    Console.WriteLine($"'{cellReference}' is not a valid cell.");
                    continue;
                }

                FiringResult result = board.FireMissile(row, column);
                switch (result)
                {
                    case FiringResult.Hit:
                        Console.WriteLine("Hit!");
                        break;
                    case FiringResult.Missed:
                        Console.WriteLine("Missed!");
                        break;
                    default:
                        Console.WriteLine("You've already been there!");
                        break;
                }

            } while(!board.IsGameWon);

            board.Print();
            Console.WriteLine("Congratulations, you Won!");
        }
    }
}
