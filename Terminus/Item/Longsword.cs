using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class Longsword: Weapon, IWeapon
    {
        public Longsword()
        {
            Damage = 6;
            Defense = 4;
            Weight = 1.8;
            Cost = 60;
        }

        public override string ToString()
        {
            return "Longsword";
        }
    }
}
