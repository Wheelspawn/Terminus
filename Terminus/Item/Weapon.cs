using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    abstract class Weapon : Item
    {
        public int Damage { get; set; }
        public int Defense { get; set; }
    }
}
