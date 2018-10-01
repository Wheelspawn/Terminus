using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class Shrine
    {
        public List<List<Terrain>> m { get; }
        public Shrine()
        {
            m.Add(new List<Terrain> { new Wall(" ╔ "), new Grass(), new Wall(" ╗ ") });
            m.Add(new List<Terrain> { new Grass(), new Altar(), new Grass() });
            m.Add(new List<Terrain> { new Wall(" ╚ "), new Grass(), new Wall(" ╝ ") });

            /* m.Add(new List<string> { " ╔ ", "   ", " ╗ " });
            m.Add(new List<string> { "   ", " ¤ ", "   " });
            m.Add(new List<string> { " ╚ ", "   ", " ╝ " });
             */

        }
    }
}
