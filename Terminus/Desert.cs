using System;
using System.Collections.Generic;

namespace Terminus
{
    class Desert : Terrain, ITerrain
    {
        List<string> graphics = new List<string> {" ┤ "," ├ ","   "};
        NPC occupant = null;
        private static int id = 1;
        public Desert()
        {
            Impassable=false;
            ID = 2;

            int c = r.Next()%15;
            if (c >= 2)
                Graphic = "   ";
            else
                Graphic = graphics[c];

        }
        public Desert(string s) : this()
        {
            Graphic = s;
        }
    }
}



