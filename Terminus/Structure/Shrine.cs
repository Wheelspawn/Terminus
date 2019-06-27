using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class Shrine
    {
        public List<List<Terrain>> m { get; }
        private OverworldFactory o;

        public Shrine()
        {
            o = new OverworldFactory();

            m = new List<List<Terrain>> {
                new List<Terrain> { o.GiveTerrain("Wall", " ╔ "), o.GiveTerrain("Grass"), o.GiveTerrain("Wall", " ╗ ") },
                new List<Terrain> { o.GiveTerrain("Grass"),       o.GiveTerrain("Altar"), o.GiveTerrain("Grass") },
                new List<Terrain> { o.GiveTerrain("Wall", " ╚ "), o.GiveTerrain("Grass"), o.GiveTerrain("Wall", " ╝ ") } };

            /* m.Add(new List<string> { " ╔ ", "   ", " ╗ " });
            m.Add(new List<string> { "   ", " ¤ ", "   " });
            m.Add(new List<string> { " ╚ ", "   ", " ╝ " });
             */

        }
    }
}
