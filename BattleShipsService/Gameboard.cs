using System;
using System.Text;

namespace BattleShipsService
{
    public class Gameboard
    {
        public const Int16 GridSize = 10;

        private Cell[,] _shipGrid = null;

        public void Setup()
        {
            _shipGrid = new Cell[GridSize, GridSize];
            for (Int32 row = 0; row < GridSize; row++)
            {
                for (Int32 column = 0; column < GridSize; column++)
                {
                    _shipGrid[row, column] = new Cell { Ship = null, Status = CellStatus.Unshelled };
                }
            }
            PlaceBattleShip();
            PlaceDestroyers();
        }

        private void PlaceBattleShip()
        {
            IShip battleShip = new BattleShip();
            Direction direction = Randomizer.Orientation;
            Int32 position1 = Randomizer.Position(battleShip.Length);
            Int32 position2 = Randomizer.Position(1);

            if (direction == Direction.Down)
            {
                for (Int32 i = 0; i < battleShip.Length; i++)
                    _shipGrid[position1 + i, position2].Ship = battleShip;
            }
            else
            {
                for (Int32 i = 0; i < battleShip.Length; i++)
                    _shipGrid[position2, position1 + i].Ship = battleShip;
            }
        }

        private void PlaceDestroyers()
        {
            PlaceDestroyer();
            PlaceDestroyer();
        }

        private void PlaceDestroyer()
        {
            //throw new NotImplementedException();
        }

        public void Print()
        {
            Console.WriteLine("     ╔═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╗");
            Console.WriteLine("     ║ A │ B │ C │ D │ E │ F │ G │ H │ I │ J ║");
            Console.WriteLine("╔════╬═══╪═══╪═══╪═══╪═══╪═══╪═══╪═══╪═══╪═══╣");
            Console.WriteLine("║  1 ║");
            Console.WriteLine("╟────╫");
            Console.WriteLine("║  2 ║");
            Console.WriteLine("╟────╫");
            Console.WriteLine("║  3 ║");
            Console.WriteLine("╟────╫");
            Console.WriteLine("║  4 ║");
            Console.WriteLine("╟────╫");
            Console.WriteLine("║  5 ║");
            Console.WriteLine("╟────╫");
            Console.WriteLine("║  6 ║");
            Console.WriteLine("╟────╫");
            Console.WriteLine("║  7 ║");
            Console.WriteLine("╟────╫");
            Console.WriteLine("║  8 ║");
            Console.WriteLine("╟────╫");
            Console.WriteLine("║  9 ║");
            Console.WriteLine("╟────╫");
            Console.WriteLine("║ 10 ║");
            Console.WriteLine("╚════╩═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╝");
        }
        
    }
}
