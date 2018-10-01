using System;
using System.Collections.Generic;

namespace Terminus
{
    class Grass: Terrain, ITerrain
    {
        // List<string> graphics = new List<string> { " ` ", " ` " };
        List<string> graphics = new List<string> {"`  "," ` ","  `","`` ","` `"," ``","```"};
        NPC occupant = null;
        private static int id = 3;
        public Grass()
        {
            Impassable=false;
            ID = 3;
            Graphic = graphics[r.Next()%graphics.Count];
        }
        public Grass(string s) : this()
        {
            Graphic = s;
        }
    }
}

