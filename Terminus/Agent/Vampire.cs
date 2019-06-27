using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class Vampire: Agent, IAgent
    {

        public Vampire()
        {
            state = new Loiter();
            Weapons = new List<Weapon> { new Dagger() };
            Health = 30;
            MaxAge = 30;
        }

        public Vampire(int m, int n)
        {
            base.m = m;
            base.n = n;
            Loiter state = new Loiter();
            Weapons = new List<Weapon> { new Dagger() };

            Health = 30;
        }


        /*
        public override void moveTo(int m, int n)
        {
            simpleMoveTo(m, n);
        }
        */

        public override string ToString()
        {
            return " V ";
        }
    }
}
