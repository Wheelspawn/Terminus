using Microsoft.GotDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus.Terminus.View
{
    class PlayerPanelsView : IView
    {
        Player _p;

        public PlayerPanelsView(Player p)
        {
            _p = p;
        }

        public void Display()
        {
            int offset = 13;
            SidePanelDisplay(offset);
            BottomPanelDisplay(offset);
        }

        public void Display(int offset)
        {
            SidePanelDisplay(offset);
            BottomPanelDisplay(offset);
        }

        public void SidePanelDisplay(int offset)
        {
            ConsoleEx.WriteAt(offset*3, 2, "(i): inventory");
            ConsoleEx.WriteAt(offset*3, 4, "(e): examine");
            ConsoleEx.WriteAt(offset*3, 6, "(t): take");
            ConsoleEx.WriteAt(offset*3, 8, "(l): look");
        }

        public void BottomPanelDisplay(int offset)
        {
            ConsoleEx.WriteAt(3, offset + 2, "Health: " + _p.Health);
            ConsoleEx.WriteAt(3, offset + 3, "Gold: " + _p.Gold);
            ConsoleEx.WriteAt(3, offset + 4, "Equipped: " + _p.Equipped);
        }
    }
}
