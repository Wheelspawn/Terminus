using System;
using System.Collections.Generic;

namespace Terminus
{
    class Lake : Terrain, ITerrain
    {
        NPC occupant = null;
        Random rand = new Random();
        private static int id = 1;
        public Lake()
        {
            Impassable=false;
            ID = 1;
            Graphic = "≈≈≈";
        }
        public Lake(string s) : this()
        {
            Graphic = s;
        }
    }
}

