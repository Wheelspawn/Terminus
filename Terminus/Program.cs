using System;
using System.Collections.Generic;
using Microsoft.GotDotNet;

namespace Terminus
{
    class Program
    {
        static void Main(string[] args)
        {
            String border_top = "  ~~~~~~~~~~~~~~~~\n";
            String border_side = "  ~              ~\n";
            String name = "  ~   TERMINVS   ~\n";
            Console.Write("\n" + border_top + border_side + name + border_side + border_top);
            Console.Write("\n Press any key to continue.");

            GameLoop g = new GameLoop();
            g.Loop();

        /*
        int m = 625;
        int n = 625;

        int offset_m = 0;
        int offset_n = 0;

        Overworld overworld = new Overworld(m,n);
        Terrain[,] map = overworld.map;

        for (int i= 0; i<25;i++)
        {
            for (int j = 0; j < 25; j++)
            {
                try
                {
                    ConsoleEx.WriteAt(i * 3 + 1, j + 1, map[i+offset_m, j+offset_n].Graphic);
                }
                catch
                {
                    ConsoleEx.WriteAt(i * 3 + 1, j + 1, "---");
                }
            }
        }
        Console.WriteLine("\n\n\n");
        */
        }
    }
}

