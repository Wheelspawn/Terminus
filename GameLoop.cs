using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.GotDotNet;
using Terminus.Terminus;
using Terminus.Terminus.Controller;
using Terminus.Terminus.View;

namespace Terminus
{
    class GameLoop
    {
        Overworld o;
        Map current_map;
        Player p;
        PlayerController p_ctrl;

        // List<NPCController> agents = new List<NPCController> { };

        String input = "";

        public GameLoop()
        {
            o = new Overworld(729, 729);
            Map current_map = o;
            p = new Player(o);
            p_ctrl = new PlayerController(p,o);
            ConsoleEx.CursorVisible = false;
        }

        public void Loop()
        {
            Random r = new Random();
            PlayerPanelsView player_panels_view = new PlayerPanelsView(p);
            MapView map_view = new MapView();

            int radius = 6;
            // o.Display(p.m,p.n, rad);
            // p_ctrl.SidePanelDisplay(rad * 2 * 3 + 4);
            // p_ctrl.BottomPanelDisplay(rad * 2 + 1);

            input = ConsoleEx.ReadChar().ToString().ToLower();

            player_panels_view.Display();

            while (input != "q")
            {
                if (input == "i")
                {
                    InventoryLoop();
                }
                else
                {
                    p_ctrl.Do(input);
                    map_view.Display(o, p.m, p.n, radius);
                }

                input = ConsoleEx.ReadChar().ToString().ToLower();
            }
            QuitLoop();
        }

        public void IntroLoop()
        {
            String border_top = "  ~~~~~~~~~~~~~~~~\n";
            String border_side = "  ~              ~\n";
            String name = "  ~   TERMINVS   ~\n";
            Console.Write("\n" + border_top + border_side + name + border_side + border_top);
            Console.Write("\n Press any key to continue.");
        }

        public void MainLoop()
        {
            
        }

        public void InventoryLoop() { }

        public void DeathLoop() { }

        public void QuitLoop() { }
    }
}
