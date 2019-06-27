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

            setGold(0.9, 25);
            if (r.NextDouble() > 0.9)
                items.Add(new Longsword());
            if (r.NextDouble() > 0.8)
                items.Add(new Shortsword());
            if (r.NextDouble() > 0.7)
                items.Add(new Dagger());

            Graphic = " ¤ "; // ¤
        }
        public Altar(string g)
        {
            Graphic = g;
            setGold(0.9, 25);
        }

        public override string ToString()
        {
            return "An altar.";
        }

        public override string ToName()
        {
            return "Altar";
        }
    }
}
