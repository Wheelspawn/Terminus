using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class Wall : Terrain, ITerrain
    {
        public Wall()
        {
            Impassable = true;
        }
        public Wall(string g)
        {
            Impassable = true;
            Graphic = g;
        }

        public override String ToName()
        {
            return "Wall";
        }
    }
}