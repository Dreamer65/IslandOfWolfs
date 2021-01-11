using System;

namespace FoxesAndChickens
{
    class Map
    {

        private const int _height = 7;
        private const int _width = 7;

        private int _chikenCount;
        private int _foxCount;
        public Map()
        {
            cells = new Cell[_height, _width];
            _chikenCount = 0;
            _foxCount = 0;
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (!((i < 2 && j < 2) || (i < 2 && j > 4) || (i > 4 && j < 2) || (i > 4 && j > 4)))
                    {
                        if (i > 2)
                        {
                            cells[i, j] = new Cell(CellVisitor.Chicken);
                            _chikenCount++;
                            continue;
                        }
                        if (i == 2 && (j == 2 || j == 4))
                        {
                            cells[i, j] = new Cell(CellVisitor.Fox);
                            _foxCount++;
                            continue;
                        }
                        cells[i, j] = new Cell(CellVisitor.None);
                    }

                }
            }

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j] == null) continue;

                    Cell top, bottom, left, right;

                    top = (i > 0) ? cells[i - 1, j] : null;
                    bottom = (i < _height - 1) ? cells[i + 1, j] : null;
                    left = (j > 0) ? cells[i, j - 1] : null;
                    right = (j < _width - 1) ? cells[i, j + 1] : null;

                    cells[i, j].SetNeighbors(top, bottom, left, right);
                }
            }
        }

        public event EventHandler MapChenged;


        private readonly Cell[,] cells;
        public Cell this[int x, int y]
        {
            get
            {
                return cells[x, y];
            }
        }

        public bool MoveUp(Cell cell)
        {
            if (cell == null) return false;
            if (cell.Visitor == CellVisitor.None) return false;

            if (cell.Visitor == CellVisitor.Chicken)
            {
                return ChickenMove(cell, Direction.Up);
            }

            if (cell.Visitor == CellVisitor.Fox)
            {
                return FoxMove(cell, Direction.Up);
            }
            return false;
        }

        public bool MoveDown(Cell cell)
        {
            if (cell == null) return false;
            if (cell.Visitor == CellVisitor.None) return false;

            if (cell.Visitor == CellVisitor.Chicken)
            {
                return ChickenMove(cell, Direction.Down);
            }

            if (cell.Visitor == CellVisitor.Fox)
            {
                return FoxMove(cell, Direction.Down);
            }
            return false;
        }

        public bool MoveLeft(Cell cell)
        {
            if (cell == null) return false;
            if (cell.Visitor == CellVisitor.None) return false;

            if (cell.Visitor == CellVisitor.Chicken)
            {
                return ChickenMove(cell, Direction.Left);
            }

            if (cell.Visitor == CellVisitor.Fox)
            {
                return FoxMove(cell, Direction.Left);
            }
            return false;
        }

        public bool MoveRight(Cell cell)
        {
            if (cell == null) return false;
            if (cell.Visitor == CellVisitor.None) return false;

            if (cell.Visitor == CellVisitor.Chicken)
            {
                return ChickenMove(cell, Direction.Right);
            }

            if (cell.Visitor == CellVisitor.Fox)
            {
                return FoxMove(cell, Direction.Right);
            }
            return false;
        }

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private Cell DirectionCell(Cell cell, Direction direction)
        {
            Cell destination;
            switch (direction)
            {
                case Direction.Up:
                    destination = cell.Top;
                    break;
                case Direction.Down:
                    destination = cell.Bottom;
                    break;
                case Direction.Left:
                    destination = cell.Left;
                    break;
                case Direction.Right:
                    destination = cell.Right;
                    break;
                default:
                    return null;
            }

            return destination;
        }

        private bool FoxMove(Cell cell, Direction direction)
        {
            Cell destination = DirectionCell(cell, direction);

            if (destination == null) return false;
            if (destination.Visitor == CellVisitor.Fox) return false;

            if (destination.Visitor == CellVisitor.None)
            {
                destination.Visitor = cell.Visitor;
                cell.Visitor = CellVisitor.None;

                MapChenged?.Invoke(this, new EventArgs());
                return true;
            }

            if (destination.Visitor == CellVisitor.Chicken)
            {
                Cell jumpDestination = DirectionCell(destination, direction);
                if (jumpDestination == null) return false;
                if (jumpDestination.Visitor != CellVisitor.None) return false;

                jumpDestination.Visitor = cell.Visitor;
                destination.Visitor = CellVisitor.None;
                _chikenCount--;
                cell.Visitor = CellVisitor.None;

                MapChenged?.Invoke(this, new EventArgs());
                return true;
            }
            return false;
        }

        private bool ChickenMove(Cell cell, Direction direction)
        {
            if (direction == Direction.Down) return false;
            Cell destination = DirectionCell(cell, direction);

            if (destination == null) return false;
            if (destination.Visitor != CellVisitor.None) return false;

            destination.Visitor = cell.Visitor;
            cell.Visitor = CellVisitor.None;

            MapChenged?.Invoke(this, new EventArgs());
            return true;
        }
    }

    enum CellVisitor
    {
        None,
        Fox,
        Chicken
    }
    class Cell
    {
        public Cell(CellVisitor visitor)
        {
            Visitor = visitor;
        }

        public CellVisitor Visitor { get; set; }
        public Cell Top { get; private set; }
        public Cell Bottom { get; private set; }
        public Cell Left { get; private set; }
        public Cell Right { get; private set; }

        public void SetNeighbors(Cell top, Cell bottom, Cell left, Cell right)
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }

    }
}
