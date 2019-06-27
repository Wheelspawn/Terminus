using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class NPC : Agent
    {
        public NPC(Map l)
        {
            Weapons = new List<Weapon>();
            Weapons.Add(new Longsword());
            Weapons.Add(new Shortsword());
            Equipped = Weapons[0];
            Gold = 50;
            Health = 100;
            m = l.DimM / 2;
            n = l.DimN / 2;
        }
    }
}
