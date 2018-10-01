using System;
using System.Collections.Generic;

namespace Terminus
{
    class Forest: Terrain, ITerrain
    {
        // List<string> graphics = new List<string> { " ¥ ", " ¥ " };
        List<string> graphics = new List<string> {"¥  "," ¥ ","  ¥","¥¥ ","¥ ¥"," ¥¥","¥¥¥"};
        NPC occupant = null;
        private static int id = 3;
        public Forest()
        {
            Impassable=false;
            ID = 4;
            Graphic = graphics[r.Next()%graphics.Count];
        }
        public Forest(string s) : this()
        {
            Graphic = s;
        }
    }
}

