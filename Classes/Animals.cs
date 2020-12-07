using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabits_Island
{
    enum AnimalType
    {
        Rabit,
        MWolf,
        FWolf
    }
    interface IAnimal
    {
        AnimalType Type { get; }
        int HP { get; }
        int Age { get; }
        void Move();
        void Spown();
    }

    class Rabit
    {
    }
}
