using System;
using System.Collections.Generic;

namespace Terminus
{
    class Desert : Terrain, ITerrain
    {
        List<string> graphics = new List<string> {" ┤ "," ├ ","   "};
        Agent occupant = null;
        private static int id = 1;
        public Desert()
        {
            setGold(0.02, 25);
            Impassable =false;
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

        public override string ToName()
        {
            return "Desert";
        }
    }
}



