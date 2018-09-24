using System;
using System.Text;

namespace BattleShipsService
{
    public class Gameboard
    {
        public const Int16 GridSize = 10;

        private const String _columnHeaders = "abcdefghij";

        private Cell[,] _cellGrid = null;
        private IShip _destroyer1 = null;
        private IShip _destroyer2 = null;
        private IShip _battleShip = null;

        /// <summary>
        /// Create the 10x10 grid and place the ships on it.
        /// </summary>
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
            _battleShip = new BattleShip();
            _destroyer1 = new Destroyer();
            _destroyer2 = new Destroyer();

            PlaceShip(_battleShip);
            PlaceShip(_destroyer1);
            PlaceShip(_destroyer2);
        }

        public static Boolean TranslateCellReference(String cellReference, out Int16 row, out Int16 column)
        {
            row = column = -1;
            if (String.IsNullOrEmpty(cellReference))
                return false;

            cellReference = cellReference.ToLower();
            Int32 index = _columnHeaders.IndexOf(cellReference[0]);
            if (index < 0)
                return false;

            column = (Int16)index;

            if (!Int32.TryParse(cellReference.Substring(1), out Int32 number))
                return false;

            if (number <= 0 || number > GridSize)
                return false;

            row = (Int16)(number-1);
            return true;
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

        /// <summary>
        /// Print the Gameboard grid.
        /// </summary>
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
                Char symbol = SymbolForCell(_cellGrid[row, column]);
                Console.Write($"{symbol} ");
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

        private static Char SymbolForCell(Cell cell)
        {
            if (cell.Status != CellStatus.Shelled)
                return ' ';

            return (cell.Ship == null) ? 'x' : '#';
        }

        public Boolean IsGameWon => _battleShip.Hits == _battleShip.Length &&
                                    _destroyer1.Hits == _destroyer1.Length &&
                                    _destroyer2.Hits == _destroyer2.Length;

        public FiringResult FireMissile(Int16 row, Int16 column)
        {
            Cell cell = _cellGrid[row, column];
            
            if (cell.Status == CellStatus.Shelled)
                return FiringResult.Repeat;

            cell.Status = CellStatus.Shelled;

            if (cell.Ship == null)
                return FiringResult.Missed;

            cell.Ship.Hits++;
            return FiringResult.Hit;
        }
    }
}
