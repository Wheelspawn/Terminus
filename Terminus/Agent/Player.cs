using Microsoft.GotDotNet;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Terminus
{
    class Player : Agent
    {
        public Player(Map l)
        {
            Weapons = new List<Weapon>();
            Weapons.Add(new Longsword());
            Weapons.Add(new Shortsword());
            Equipped = Weapons[0];
            Gold = 50;
            Health = 100;
            m=l.DimM/2;
            n=l.DimN/2;
        }

        public override string ToString()
        {
            return " @ ";
        }
    }
}