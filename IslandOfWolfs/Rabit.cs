using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandOfWolfs
{
    class Rabit : IAnimal
    {
        public Rabit(Cell position, Random random)
        {
            _random = random;
            _position = position;
            _hp = 1;
            _age = 0;
            Position.AddAnimal(this);
        }

        private Random _random;

        public AnimalType Type { get => AnimalType.Rabit; }

        private Cell _position;
        public Cell Position { get => _position; }

        private double _hp;
        public double HP { get => _hp; }

        private int _age;

        public event EventHandler Death;

        public int Age { get => _age; }

        public void Move()
        {
            if (Position.Neighbors.Count == 0) return;

            int newPosCount = _random.Next() % (Position.Neighbors.Count + 1);

            if (newPosCount == Position.Neighbors.Count) return;

            Cell newPosition = Position.Neighbors[newPosCount];

            Position.DelAnimal(this);
            newPosition.AddAnimal(this);
            _position = newPosition;
        }

        public override string ToString()
        {
            return "R";
        }

        public void Die()
        {
            Position?.DelAnimal(this);
            _position = null;
            _hp = 0;
            Death?.Invoke(this, new EventArgs());
        }

        public IAnimal Reproduction()
        {
            int count = 0;
            foreach (IAnimal item in Position.Animals)
            {
                if (item is Rabit) count++;
            }
            if (count >= 3) return null;

            int tmp = _random.Next();
            tmp %= 5;

            if (tmp == 3)
            {
                return new Rabit(Position, _random);
            }
            return null;
        }

        public void Eat() { }
    }
}
