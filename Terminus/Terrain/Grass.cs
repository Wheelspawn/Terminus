using System;
using System.Collections.Generic;

namespace Terminus
{
    class Grass: Terrain, ITerrain
    {
        // List<string> graphics = new List<string> { " ` ", " ` " };
        List<string> graphics = new List<string> {"`  "," ` ","  `","`` ","` `"," ``","```"};
        Agent occupant = null;
        private static int id = 3;
        public Grass()
        {
            setGold(0.02, 25);
            Impassable=false;
            ID = 3;
            Graphic = graphics[r.Next()%graphics.Count];
        }
        public Grass(string s) : this()
        {
            Graphic = s;
        }

        public override string ToName()
        {
            return "Grass";
        }
    }
}

