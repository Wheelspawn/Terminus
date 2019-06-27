using System;
using System.Collections.Generic;
using Microsoft.GotDotNet;

namespace Terminus
{
    abstract class Terrain : ITerrain
    {
        public Terrain() { Occupant = null; }

        private Map m;

        public List<Item> items = new List<Item>() { };
        public static List<String> terrainList = new List<String>() { "Desert", "Grass", "Lake", "Forest", "Mountain" };

        public readonly int rel_m;
        public readonly int rel_n;

        protected static Random r = new Random();

        public int Gold { get; set; }
        public string Graphic { get; set; }
        public int ID  { get; set; }
        public bool Impassable { get; set; }
        public Agent Occupant { get; set; }

        public bool isImpassable()
        {
            if (Impassable == true) return true;
            else return false;
        }
        public bool isOccupied()
        {
            if (Occupant==null) return false;
            else return true;
        }

        public void setGold(double chance, int amount_range)
        {
            if (r.NextDouble() < chance)
            {
                Gold = r.Next(1, amount_range);
            }
        }

        public void removeItem(List<Item> items)
        {
            for (int i=0;i<items.Count;i++)
            {
                removeItem(items[i]);
            }
        }

        public void removeItem(Item item)
        {
            if (this.items.Contains(item));
            {
                this.items.Remove(item);
            }
        }

        public void giveInfo()
        {
            ConsoleEx.WriteAt(1, 1, "Hiya, folks.");
        }

        public abstract String ToName();
    }
}
