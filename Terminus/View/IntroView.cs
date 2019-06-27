using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus.Terminus.View
{
    class IntroView : IView
    {
        public void Display()
        {
            String border_top = "  ~~~~~~~~~~~~~~~~\n";
            String border_side = "  ~              ~\n";
            String name = "  ~   TERMINVS   ~\n";
            Console.Write("\n" + border_top + border_side + name + border_side + border_top);
            Console.Write("\n Press any key to continue.");
        }
    }
}
