using System;
using Microsoft.GotDotNet;

namespace Terminus
{
    class Program
    {
        static void Main(string[] args)
        {

            Overworld o = new Overworld();
            // o.midPoint(15*15*15);
            Player p = new Player(o.m);

            ConsoleEx.CursorVisible = false;

            o.Display(p);

            // ConsoleKey g = Console.ReadKey().Key;
            char g = (Char)ConsoleEx.ReadChar();

            do
            {
                // Console.Clear();
                o.Display(p);
                // g = Console.ReadKey().Key;
                g = (Char)ConsoleEx.ReadChar();
                p.Move(g);
            } while (g!='Q');
        }
    }
}

