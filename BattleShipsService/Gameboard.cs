using System;
using System.Text;

namespace BattleShipsService
{
    public class Gameboard
    {
        public const Int16 GridSize = 10;

        private Cell[,] _cellGrid = null;

        public void Setup()
        {
            _cellGrid = new Cell[GridSize, GridSize];
            for (Int32 row = 0; row < GridSize; row++)
            {
                for (Int32 column = 0; column < GridSize; column++)
                {
                    _cellGrid[row, column] = new Cell { Ship = null, Status = CellStatus.Unshelled };
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
                    _cellGrid[position1 + i, position2].Ship = battleShip;
            }
            else
            {
                for (Int32 i = 0; i < battleShip.Length; i++)
                    _cellGrid[position2, position1 + i].Ship = battleShip;
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
            Console.Write("     ╔═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╗\n");
            Console.Write("     ║ A │ B │ C │ D │ E │ F │ G │ H │ I │ J ║\n");
            Console.Write("╔════╬═══╪═══╪═══╪═══╪═══╪═══╪═══╪═══╪═══╪═══╣\n");

            for (Int16 row = 0; row < GridSize; row++)
                PrintRow(row);
        }

        private void PrintRow(Int16 row)
        {
            if (row == GridSize-1)
                Console.Write($"║ {row+1} ║");
            else
                Console.Write($"║  {row+1} ║");
                
            for (Int16 column = 0; column < GridSize; column++)
            {
                Console.Write(" ");
                Cell cell = _cellGrid[row, column];
                if (cell.Ship != null)
                    Console.Write($"{cell.Ship.Name[0]} ");
                else
                    Console.Write("  ");
                if (column == GridSize-1)
                    Console.WriteLine("║");
                else
                    Console.Write("│");
            }
            if (row == GridSize-1)
                Console.Write("╚════╩═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╝\n");
            else
                Console.Write("╟────╫───┼───┼───┼───┼───┼───┼───┼───┼───┼───╢\n");
        }
    }
}
