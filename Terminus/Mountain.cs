using System;

namespace Terminus
{
    class Mountain: Terrain, ITerrain
    {
        NPC occupant = null;
        Random rand = new Random();
        private static int id = 3;
        public Mountain()
        {
            Impassable=true;
            ID = 5;
            Graphic = " ^ ";
        }
        public Mountain(string s) : this()
        {
            Graphic = s;
        }
    }
}