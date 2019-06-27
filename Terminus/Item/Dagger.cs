using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class Dagger : Weapon, IWeapon
    {
        public Dagger()
        {
            Damage = 3;
            Defense = 2;
            Weight = 0.6;
            Cost = 30;
        }

        public override string ToString()
        {
            return "Dagger";
        }
    }
}