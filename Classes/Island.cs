using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabits_Island
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
    }

    class Island
    {

        private Cell[,] cells;
        public Island(int weight, int height)
        {
            cells = new Cell[weight, height];
            
            for(int i = 0; i < weight; i++)
                for(int j = 0; j < height; j++)
                   cells[i, j] = new Cell(new Point(i, j));

            for(int i = 0; i < weight; i++)
                for(int j = 0; j < height; j++)
                    for (int iOffset = -1; iOffset <= 1; iOffset++)
                        for(int jOffset = -1; jOffset <= 1; jOffset++)
                        {
                            if (i + iOffset < 0 || i + iOffset >= weight) continue;
                            if (j + jOffset < 0 || j + jOffset >= height) continue;

                            cells[i, j].Neighbors.Add(cells[i + iOffset, j + jOffset]);
                        }




        }


        public Cell this[int x, int y]
        {
            get { return null; }
        }
    }
}
