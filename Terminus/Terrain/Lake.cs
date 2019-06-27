using System;
using System.Collections.Generic;

namespace Terminus
{
    class Lake : Terrain, ITerrain
    {
        Agent occupant = null;
        Random rand = new Random();
        private static int id = 1;
        public Lake()
        {
            setGold(0.02, 25);
            Impassable =false;
            ID = 1;
            Graphic = "≈≈≈";
        }
        public Lake(string s) : this()
        {
            Graphic = s;
        }

        public override String ToName()
        {
            return "Lake";
        }
    }
}

