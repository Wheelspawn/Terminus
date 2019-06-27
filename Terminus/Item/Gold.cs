using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class Gold : Item
    {
        
        public Gold(int cost)
        {
            Cost = cost;
            Weight = 0.0;
        }

        public override string ToString()
        {
            return Cost + " gold";
        }
    }
}
