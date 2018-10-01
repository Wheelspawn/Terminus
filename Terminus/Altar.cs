using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class Altar : Terrain, ITerrain
    {
        public Altar()
        {
            Graphic = " ¤ ";
        }
        public Altar(string g)
        {
            Graphic = g;
        }
    }
}
