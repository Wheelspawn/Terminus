using Microsoft.GotDotNet;
using System;
using System.Collections.Generic;

namespace Terminus
{
    abstract class Map
    {
        // our map object. terrain is dynamically generated.

        public List<List<Terrain>> m { get; }

        OverworldFactory o = new OverworldFactory();

        public Map() { m = new List<List<Terrain>>(); }

        public virtual void Generate() { }

        // grow the map
        public virtual void Grow(char d) {}

        public int DimM {get { return m.Count; } }

        public int DimN {get { return m[0].Count; } }

        public void Display(Player p)
        {
            try
            {

                ConsoleEx.WriteAt(40, 10, m.Count.ToString());
                ConsoleEx.WriteAt(40, 11, m[1].Count.ToString());

                for (int i=p.M-5;i<p.M+6;i++)
                {
                    for (int j=p.N-5;j<p.N+6;j++)
                    {
                        if (i==p.M && j==p.N)
                            ConsoleEx.WriteAt((j - p.N + 6)*3, (i - p.M) + 6, " @ "); // ☺
                        else
                            ConsoleEx.WriteAt((j - p.N + 6)*3, (i - p.M) + 6, m[i][j].Graphic);
                    }
                    // Console.WriteLine();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Console.Clear();
                // north
                if (p.M == 4)
                {
                    p.M=5;
                    Grow('w');
                    p.M += 21;
                }
                // west
                if (p.N == 4)
                {
                    p.N=5;
                    Grow('a');
                    p.N += 21;
                }
                // south
                if (p.M+5>=m.Count)
                {
                    Grow('s');
                }
                // east
                if (p.N+5>=m[1].Count)
                {
                    Grow('d');
                }
                Display(p);
            }
        }
    }
}

