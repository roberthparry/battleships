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

            PlaceShip(battleShip);
        }

        private void PlaceDestroyers()
        {
            PlaceDestroyer();
            PlaceDestroyer();
        }

        private void PlaceDestroyer()
        {
            IShip destroyer = new Destroyer();

            PlaceShip(destroyer);
        }

        private void PlaceShip(IShip ship)
        {
            Direction direction;
            Int32 position1;
            Int32 position2;

            do {
                direction = Randomizer.Orientation;
                position1 = Randomizer.Position(ship.Length);
                position2 = Randomizer.Position(1);
            } while (!CanPlaceShip(ship, position1, position2, direction));

            DoPlaceShip(ship, position1, position2, direction);
        }

        private void DoPlaceShip(IShip ship, Int32 position1, Int32 position2, Direction direction)
        {
            if (direction == Direction.Down)
            {
                for (Int32 i = 0; i < ship.Length; i++)
                    _cellGrid[position1 + i, position2].Ship = ship;
            }
            else
            {
                for (Int32 i = 0; i < ship.Length; i++)
                    _cellGrid[position2, position1 + i].Ship = ship;
            }
        }

        private Boolean CanPlaceShip(IShip ship, Int32 position1, Int32 position2, Direction direction)
        {
            if (direction == Direction.Down)
            {
                for (Int32 i = 0; i < ship.Length; i++)
                {
                    if (_cellGrid[position1 + i, position2].Ship != null)
                        return false;
                }
                    
            }
            else
            {
                for (Int32 i = 0; i < ship.Length; i++)
                {
                    if (_cellGrid[position2, position1 + i].Ship != null)
                        return false;
                }
            }
            return true;
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
