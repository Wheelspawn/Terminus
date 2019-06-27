using Microsoft.GotDotNet;
using System;
using System.Collections.Generic;

namespace Terminus
{
    abstract class Map
    {
        // our map object. terrain is dynamically generated.

        public Terrain[,] map { get; set;  }

        OverworldFactory o = new OverworldFactory();

        public Map() { Terrain[,] map; }

        public virtual void Generate() { }

        // grow the map
        public virtual void Grow(char d) {}

        public int DimM {get { return map.GetLength(0); } }

        public int DimN {get { return map.GetLength(1); } }

        public void Display(int m, int n, int rad)
        {
            // Console.Clear();
            string reset_line = "                ";
            
            for (int i=-rad+1; i<rad;i++)
            {
                for (int j = -rad + 1; j < rad; j++)
                {
                    try
                    {
                        ConsoleEx.WriteAt(3, rad * 2, reset_line);
                        ConsoleEx.WriteAt(3, rad * 2 + 1, reset_line);

                       ConsoleEx.WriteAt((i + rad) * 3, j + rad, map[m + i, n + j].Graphic);
                        if (map[m + i, n + j].isOccupied() == true)
                        {
                            ConsoleEx.WriteAt((i + rad) * 3, j + rad, map[m + i, n + j].Occupant.ToString());
                        }
                        if (map[m + i, n + j].Gold > 0)
                        {
                            ConsoleEx.WriteAt(3, rad * 2, ("Found "+map[m + i, n + j].Gold.ToString()+" Gold").ToString());
                        }
                        if (map[m + i, n + j].items.Count > 0)
                        {
                            ConsoleEx.WriteAt(3, rad * 2 + 1, map[m + i, n + j].items[0].ToString());
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        ConsoleEx.WriteAt((i + rad) * 3, j + rad, " ^ ");
                    }
                }
            }
        }

        public void Move(Agent npc, int new_m, int new_n)
        {
            try
            {
                map[new_m, new_n].Occupant = npc;
                map[npc.m, npc.n].Occupant = null;
                npc.m = new_m;
                npc.n = new_n;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        
        public void Move(Player _p, int new_m, int new_n)
        {
            try
            {
                map[new_m, new_n].Occupant = _p;
                map[_p.m, _p.n].Occupant = null;
                _p.m = new_m;
                _p.n = new_n;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        public void Move(Player p, char c)
        {

        }
    }
}

