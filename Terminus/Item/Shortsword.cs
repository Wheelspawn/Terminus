using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class Shortsword: Weapon, IWeapon
    {
        public Shortsword()
        {
            Damage = 5;
            Defense = 5;
            Weight = 1.6;
            Cost = 50;
        }

        public override string ToString()
        {
            return "Shortsword";
        }
    }
}