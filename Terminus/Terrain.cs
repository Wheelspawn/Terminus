using System;
using System.Collections.Generic;

namespace Terminus
{
    abstract class Terrain : ITerrain
    {
        NPC occupant;
        public Terrain() { }

        public static List<String> terrainList = new List<String>() { "Desert", "Grass", "Lake", "Forest", "Mountain" };
        private Map m;

        public readonly int rel_m;
        public readonly int rel_n;

        protected static Random r = new Random();

        public string Graphic { get; set; }
        public int ID  { get; set; }
        public bool Impassable { get; set; }

        public bool isImpassable()
        {
            if (isOccupied() == true || Impassable == true) return true;
            else return false;
        }
        public bool isOccupied()
        {
            if (occupant==null) return false;
            else return true;
        }

    }
}
