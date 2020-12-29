using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandOfWolfs
{
    class MWolf : IAnimal
    {
        public MWolf(Cell position, Random random)
        {
            _random = random;
            _position = position;
            _hp = 1;
            _age = 0;
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

            Cell newPosition = Position.Neighbors[0];
            Position.DelAnimal(this);
            newPosition.AddAnimal(this);
            _position = newPosition;
        }

        public override string ToString()
        {
            return "MW:" + HP.ToString();
        }

        public void Die()
        {
            Position?.DelAnimal(this);
            _position = null;
            Death?.Invoke(this, new EventArgs());
        }

        public IAnimal Reproduction()
        {
            int tmp = _random.Next(1000);
            tmp %= 5;

            if (tmp == 3)
            {
                return new Rabit(Position, _random);
            }
            return null;
        }
    }
}
