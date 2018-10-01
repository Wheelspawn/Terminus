using Microsoft.GotDotNet;
using System;
using System.Collections.Generic;

namespace Terminus
{
    class Player
    {
        private List<List<Terrain>> map;
        public int M {get;set;}
        public int N {get;set;}
        public Player(List<List<Terrain>> m)
        {
            map = m;
            M=5;
            N=5;
        }

        public void Move(char d)
        {
            switch (d)
            {
                case 'w': // north
                    if (map[M-1][N].Impassable != true)
                        M -= 1;
                    break;
                case 's': // south
                    if (map[M + 1][N].Impassable != true)
                        M += 1;
                    break;
                case 'a': // west
                    if (map[M][N-1].Impassable != true)
                        N -= 1;
                    break;
                case 'd': // east
                    if (map[M][N+1].Impassable != true)
                        N += 1;
                    break;
                default:
                    break;
            }
        }

        public void Move(ConsoleKey d)
        {
            switch (d)
            {
                case ConsoleKey.W: // north
                    M-=1;
                    break;
                case ConsoleKey.S: // south
                    M+=1;
                    break;
                case ConsoleKey.A: // west
                    N-=1;
                    break;
                case ConsoleKey.D: // east
                    N+=1;
                    break;
                default:
                    break;
            }
        }
    }
}