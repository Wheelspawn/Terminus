using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus.Terminus.Controller
{
    class NPCController : IController
    {
        NPC _npc;
        Map _m;

        public NPCController(NPC npc, Map m)
        {
            _npc = npc;
            _m = m;

        }
        public void Do(String s)
        {
            Do();
        }
        public void Do()
        {
            Dictionary<String, Tuple<int, int>> dirs = new Dictionary<String, Tuple<int, int>>
            { { "w", new Tuple<int, int>(-1, 0) },
              { "a", new Tuple<int, int>(0, -1) },
              { "s", new Tuple<int, int>(1, 0) },
              { "d", new Tuple<int, int>(0, 1)} };
            Random r = new Random();
            String s = new List<String> { "w", "a", "s", "d" }[r.Next(4)];

            Terrain currentCell = _m.map[_npc.m, _npc.n];

            int new_m = _npc.m + dirs[s].Item2;
            int new_n = _npc.n + dirs[s].Item1;

            Terrain newCell = _m.map[new_m, new_n];

            if (newCell.isImpassable() && newCell.isOccupied())
                _m.Move(_npc, new_m, new_n);
        }
    }
}
