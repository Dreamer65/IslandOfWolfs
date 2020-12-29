using System;

namespace IslandOfWolfs
{
    enum AnimalType
    {
        None,
        Rabit,
        MWolf,
        FWolf,
        Multy
    }
    interface IAnimal
    {
        AnimalType Type { get; }
        Cell Position { get; }
        double HP { get; }
        int Age { get; }
        void Move();
        void Eat();
        void Die();
        event EventHandler Death;
        IAnimal Reproduction();
    }
}
