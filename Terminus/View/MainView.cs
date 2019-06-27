using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus.Terminus.View
{
    class MainView
    {
        Map _m;
        Player _p;

        InventoryView inv_view;
        MapView map_view;
        PlayerPanelsView player_panels_view;

        public MainView(Map m, Player p)
        {
            _m = m;
            _p = p;

            player_panels_view = new PlayerPanelsView(_p);
            map_view = new MapView();
        }

        public void Display()
        {

        }
    }
}
