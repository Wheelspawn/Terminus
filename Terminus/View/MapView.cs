using Microsoft.GotDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus.Terminus.View
{
    class MapView
    {
        public void Display(Map map, int m_0, int n_0, int m_1, int n_1)
        {
            string reset_line = "                                ";

            for (int i = 0; i < m_1-m_0; i++)
            {
                for (int j = 0; j < n_1-n_0; j++)
                {
                    try
                    {
                        if (map.map[i+m_0, j+n_0].Occupant == null)
                            ConsoleEx.WriteAt(i * 3 + 1, j + 1, map.map[i+m_0, j+n_0].Graphic);
                        else
                            ConsoleEx.WriteAt(i * 3 + 1, j + 1, map.map[i + m_0, j + n_0].Occupant.ToString());
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        ConsoleEx.WriteAt(i * 3 + 1, j + 1, "   ");
                    }
                }
            }
        }

        public void Display(Map map, int m, int n, int radius)
        {
            this.Display(map, m - radius + 1, n - radius + 1, m + radius, n + radius);
        }
    }
}
