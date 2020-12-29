using System;

namespace IslandOfWolfs
{
    class FWolf : IAnimal
    {
        public FWolf(Cell position, Random random)
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

        private Cell SearchRabit()
        {
            foreach (IAnimal animal in Position.Animals)
            {
                if (animal is Rabit) return null;
            }

            foreach (Cell cell in Position.Neighbors)
            {
                foreach (IAnimal animal in cell.Animals)
                {
                    if (animal is Rabit) return cell;
                }
            }
            return null;
        }

        private Cell SearchFWolf()
        {
            foreach (Cell cell in Position.Neighbors)
            {
                foreach (IAnimal animal in cell.Animals)
                {
                    if (animal is FWolf) return cell;
                }
            }
            return null;
        }

        public void Move()
        {
            if (Position.Neighbors.Count == 0) return;

            if (HP <= 0)
            {
                Die();
                return;
            }
            _hp -= 0.1;

            Cell newPosition = SearchRabit();

            if (newPosition == null)
            {
                int newPosCount = _random.Next() % (Position.Neighbors.Count + 1);

                if (newPosCount == Position.Neighbors.Count) return;

                newPosition = Position.Neighbors[newPosCount];
            }

            Position.DelAnimal(this);
            newPosition.AddAnimal(this);
            _position = newPosition;
        }

        public override string ToString()
        {
            return "FW:" + HP.ToString();
        }

        public void Die()
        {
            Position?.DelAnimal(this);
            _position = null;
            if (Death == null)
                return;
            Death?.Invoke(this, new EventArgs());
        }

        public IAnimal Reproduction()
        {
            foreach (IAnimal animal in Position.Animals)
            {
                if (animal is MWolf)
                    if (_random.Next()%2 == 1)
                        return new MWolf(Position, _random);
                    else
                        return new FWolf(Position, _random);
            }
            return null;
        }

        public void Eat()
        {
            IAnimal animal = null;
            foreach (IAnimal item in Position.Animals)
            {
                if (item is Rabit)
                {
                    animal = item;
                    break;
                }
            }
            if(animal != null)
            {
                    animal.Die();
                    _hp += 1;
            }
        }
    }
}
