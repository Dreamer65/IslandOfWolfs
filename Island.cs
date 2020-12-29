using System;
using System.Collections.Generic;

namespace IslandOfWolfs
{
    struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public List<Point> Around(int radius)
        {
            List<Point> result = new List<Point>();
            for (int x = X - radius; x < X + radius; x++)
                for (int y = Y - radius; y < Y + radius; y++)
                    result.Add(new Point(x, y));
            return result;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;

            if (((Point)obj).X == this.X && ((Point)obj).Y == this.Y) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("X:{0}; Y:{1};", X, Y);
        }

        public static bool operator ==(Point obj1, Point obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Point obj1, Point obj2)
        {
            return !obj1.Equals(obj2);
        }
    }
    class Cell
    {
        public Cell(Point location)
        {
            Location = location;
            Animals = new List<IAnimal>();
            Neighbors = new List<Cell>();
        }

        public AnimalType Owner
        {
            get
            {
                if (IsEmpty) return AnimalType.None;
                foreach (IAnimal item in Animals)
                {
                    if (item is Rabit) return AnimalType.Rabit;
                }
                foreach (IAnimal item in Animals)
                {
                    if (item is FWolf) return AnimalType.FWolf;
                }
                foreach (IAnimal item in Animals)
                {
                    if (item is MWolf) return AnimalType.MWolf;
                }

                return AnimalType.None;
            }
        }

        public Point Location { get; }

        public List<Cell> Neighbors;

        public List<IAnimal> Animals { get; }

        public bool IsEmpty
        {
            get { return Animals.Count == 0; }
        }
        public void AddAnimal(IAnimal animal)
        {
            Animals.Add(animal);
        }

        public void DelAnimal(IAnimal animal)
        {
            Animals.Remove(animal);
        }

        public override string ToString()
        {
            string str = "";

            foreach (IAnimal item in Animals)
            {
                str += item.ToString() + "; " + Environment.NewLine;
            }

            return str;
        }
    }

    class Island
    {

        private Cell[,] cells;

        private List<IAnimal> Animals { get; }
        Random _random;
        public Island(int width, int height)
        {
            _random = new Random();
            _height = height;
            _width = width;
            cells = new Cell[width, height];
            Animals = new List<IAnimal>();

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    cells[i, j] = new Cell(new Point(i, j));

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    for (int iOffset = -1; iOffset <= 1; iOffset++)
                        for (int jOffset = -1; jOffset <= 1; jOffset++)
                        {
                            if (i + iOffset < 0 || i + iOffset >= width) continue;
                            if (j + jOffset < 0 || j + jOffset >= height) continue;

                            cells[i, j].Neighbors.Add(cells[i + iOffset, j + jOffset]);
                        }
        }

        public Island(int width, int height, int rabitsCount, int FWolfsCount, int MWolfsCount) : this(width, height)
        {
            Cell tmp;
            IAnimal animal;

            for(int i = 0; i<rabitsCount; i++)
            {
                tmp = RandomEmptyCell();
                if (tmp != null)
                {
                    animal = new Rabit(tmp, _random);
                    tmp.AddAnimal(animal);
                    Animals.Add(animal);
                }
            }

            for (int i = 0; i < FWolfsCount; i++)
            {
                tmp = RandomEmptyCell();
                if (tmp != null)
                {
                    animal = new FWolf(tmp, _random);
                    tmp.AddAnimal(animal);
                    Animals.Add(animal);
                }
            }

            for (int i = 0; i < MWolfsCount; i++)
            {
                tmp = RandomEmptyCell();
                if (tmp != null)
                {
                    animal = new MWolf(tmp, _random);
                    tmp.AddAnimal(animal);
                    Animals.Add(animal);
                }
            }

        }

        private Cell RandomEmptyCell()
        {
            bool isEmptyCellExist = false;
            foreach (Cell item in cells)
            {
                if (item.IsEmpty) isEmptyCellExist = true;
            }
            if (!isEmptyCellExist) return null;

            int maxX = cells.GetLength(0);
            int maxY = cells.GetLength(1);

            Random random = new Random();

            int x;
            int y;

            do
            {
                x = random.Next(maxX);
                y = random.Next(maxY);
            } while (!cells[x, y].IsEmpty);

            return cells[x, y];

        }

        private int _height;
        public int Height { get => _height; }

        private int _width;
        public int Width { get => _width; }

        public Cell this[int x, int y]
        {
            get { return cells[x, y]; }
        }

        public void Step()
        {
            foreach (IAnimal item in Animals)
            {
                item.Move();
            }
        }
    }
}
