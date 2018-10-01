using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus.Terminus
{
    class Block
    {
        private string type;
        private Terrain[][] blk;
        

        public Block(string t)
        {
            type = t;
            blk = new Terrain[15][];
            for (int i = 0; i < 15; i++)
            {
                blk[i] = new Terrain[15];
            }
        }
        
        public Block() { }
    }
}
