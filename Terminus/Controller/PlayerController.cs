using Microsoft.GotDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terminus.Terminus.Controller;

namespace Terminus.Terminus
{
    class PlayerController : IController
    {
        Player _p;
        Map _m;

        public PlayerController(Player p, Map m)
        {
            _p = p;
            _m = m;
        }

        public void Do(String s)
        {
            s = s.ToLower();
            Dictionary<String, Tuple<int, int>> dirs = new Dictionary<String, Tuple<int, int>>
            { { "w", new Tuple<int, int>(-1, 0) },
              { "a", new Tuple<int, int>(0, -1) },
              { "s", new Tuple<int, int>(1, 0) },
              { "d", new Tuple<int, int>(0, 1)} };

            Terrain currentCell = _m.map[_p.m, _p.n];
            
            switch (s)
            {
                case "w":
                case "a":
                case "s":
                case "d":

                    int new_m = _p.m + dirs[s].Item2;
                    int new_n = _p.n + dirs[s].Item1;

                    Terrain newCell = _m.map[new_m, new_n];

                    if (newCell.isImpassable())
                    {
                        break;
                    }
                    if (newCell.isOccupied())
                    {
                        // if not friendly, etc., do combat sequence
                        break;
                    }
                    else
                    {
                        _m.Move(_p,new_m,new_n);
                        // ConsoleEx.WriteAt(5, 15, "Player m: ");
                        // ConsoleEx.WriteAt(5, 15, "Player n: ");
                        // ConsoleEx.WriteAt(5, 15, "Current cell m: "+currentCell.rel_m);
                        // ConsoleEx.WriteAt(5, 15, "Player n: "+currentCell.rel_n);
                        break;
                    }
                case "t": // take
                    this.Take(currentCell);
                    break;
                case "l": // look
                    currentCell.giveInfo();
                    break;
                default:
                    break;
            }
        }

        public void Take(Terrain currentCell)
        {
            if (currentCell.Gold > 0)
            {
                _p.Gold += currentCell.Gold;
                currentCell.Gold = 0;
            }
            if (currentCell.items.Count > 0)
            {
                if (currentCell.items[0].GetType() is Weapon)
                {
                    _p.Weapons.Add((Weapon)currentCell.items[0]);
                }
            }
        }

        public void SidePanelDisplay(int offset)
        {
            ConsoleEx.WriteAt(offset, 2, "(i): inventory");
            ConsoleEx.WriteAt(offset, 4, "(e): examine");
            ConsoleEx.WriteAt(offset, 6, "(t): take");
            ConsoleEx.WriteAt(offset, 6, "(l): look");
        }

        public void BottomPanelDisplay(int offset)
        {
            ConsoleEx.WriteAt(3, offset + 2, "Health: "+_p.Health);
            ConsoleEx.WriteAt(3, offset + 3, "Gold: "+_p.Gold);
            ConsoleEx.WriteAt(3, offset + 4, "Equipped: " + _p.Equipped);

        }
    }
}
