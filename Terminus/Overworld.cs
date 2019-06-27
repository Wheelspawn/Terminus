using System;
using System.Collections;
using System.Collections.Generic;

namespace Terminus
{
    class Overworld : Map
    {
        OverworldFactory o = new OverworldFactory();
        Random r = new Random();
        List<Agent> npcs = new List<Agent>();

        public Overworld(int m, int n)
        {
            map = new Terrain[m, n];
            generateWithMidpoint(map,m-1,n-1);
        }

        public Terrain[,] generateWithMidpoint(Terrain[,] map, int m, int n)
        {
            List<String> terrains = new List<String> { "Lake", "Grass", "Desert", "Forest", "Mountain" };

            String t_left = terrains[r.Next(terrains.Count)];
            terrains.Remove(t_left);
            String t_right = terrains[r.Next(terrains.Count)];
            terrains.Remove(t_right);
            String b_left = terrains[r.Next(terrains.Count)];
            terrains.Remove(b_left);
            String b_right = terrains[r.Next(terrains.Count)];

            // initializing the corner values
            map[0, 0] = o.GiveTerrain(t_left);
            map[0, n] = o.GiveTerrain(t_right);
            map[m , 0] = o.GiveTerrain(b_left);
            map[m , n] = o.GiveTerrain(b_right);

            generateSection(map, 0, 0, m, n);

            // setting the map boundaries
            for (int i=0;i<m;i++)
            {
                map[i,0] = new Mountain();
                map[i,map.GetLength(0) - 1] = new Mountain();
            }
            for (int j = 0; j < n; j++)
            {
                map[0, j] = new Mountain();
                map[map.GetLength(1) - 1, j] = new Mountain();
            }

            // setting map center
            for (int i = (m/2)-3; i < (m/2)+4; i++)
            {
                for (int j = (n / 2) - 3; j < (n / 2) + 4; j++)
                {
                    map[i,j] = new Grass();
                }
            }

            return map;
        }

        public void generateSection(Terrain[,] map, int m_0, int n_0, int m_1, int n_1)
        {
            /*
            Console.WriteLine(m_0);
            Console.WriteLine(n_0);
            Console.WriteLine(m_1);
            Console.WriteLine(n_1);
            Console.WriteLine(); */

            if ((m_1 - m_0 < 2) && (n_1 - n_0 < 2))
            {
                return;
            }
            else
            {
                List<String> terrains = new List<String> { "Lake", "Grass", "Desert", "Forest", "Mountain" };

                String t_left = map[m_0,n_0].ToName();
                String t_right = map[m_1, n_0].ToName();
                String b_left = map[m_0, n_1].ToName();
                String b_right = map[m_1, n_1].ToName();

                // intializing the center value
                map[(m_0+m_1)/2,(n_0+n_1)/2] = o.GiveTerrain(new List<String> {
                    t_left,
                    t_right,
                    b_left,
                    b_right,
                    terrains[r.Next(5)] }[r.Next(5)]);

                // initializing the side values
                map[(m_0 + m_1) / 2, n_0] = o.GiveTerrain(new List<String> { t_left, b_left }[r.Next(2)]);
                map[(m_0 + m_1) / 2, n_1] = o.GiveTerrain(new List<String> { t_right, b_right }[r.Next(2)]);
                map[m_0, (n_0 + n_1) / 2] = o.GiveTerrain(new List<String> { t_left, t_right }[r.Next(2)]);
                map[m_1, (n_0 + n_1) / 2] = o.GiveTerrain(new List<String> { b_left, b_right }[r.Next(2)]);

                generateSection(map, m_0, n_0, (m_0 + m_1) / 2, (n_0 + n_1) / 2);
                generateSection(map, m_0, (n_0 + n_1) / 2, (m_0 + m_1) / 2, n_1);
                generateSection(map, (m_0 + m_1) / 2, n_0, m_1, (n_0 + n_1) / 2);
                generateSection(map, (m_0 + m_1) / 2, (n_0 + n_1) / 2, m_1, n_1);
            }
        }
        
        /*
        private Terrain getRandomTerrain(int i, int j)
        {
            // Random r = new Random();
            if (r.NextDouble() > 0.1) // return same type
            {
                List<Terrain> adj = adjacents(map, i, j);
                // Console.WriteLine(adj[r.Next(0, adj.Count)]);
                return adj[r.Next(0,adj.Count)];
            }
            else // return random
            {
                // Console.WriteLine(o.GiveTerrain(Terrain.terrainList[r.Next(0, Terrain.terrainList.Count)]));
                return o.GiveTerrain(Terrain.terrainList[r.Next(0, Terrain.terrainList.Count)]);
            }
        } */
        
        /*
        public override void Grow(char d)
        {
            Random r = new Random();
            int s = Terrain.terrainList.Count;
            for (int l = 0; l < 22; l++)
            {
                switch (d)
                {
                    case 'd': // east
                        for (int i = 0; i < map.Count; i++)
                            map[i].Insert(map[i].Count, getRandomTerrain(i, map[0].Count - 1));
                        break;
                    case 'w': // north
                        map.Insert(0, new List<Terrain>());
                        for (int i = 0; i < map[1].Count; i++)
                            map[0].Add(getRandomTerrain(1, i));
                        break;
                    case 'a': // west
                        for (int i = 0; i < map.Count; i++)
                            map[i].Insert(0, getRandomTerrain(i, 1));
                        break;
                    case 's': // south
                        map.Insert(map.Count, new List<Terrain>());
                        for (int i = 0; i < map[0].Count; i++)
                            map[map.Count - 1].Add(getRandomTerrain(map.Count - 1, i));
                        break;
                    default:
                        break;
                }
            }

            if (r.NextDouble() > 0.33)
            {

                Dictionary<char, Tuple<int, int>> bounds = new Dictionary<char, Tuple<int, int>>
                { { 'w', new Tuple<int, int>(-1, 0) },
                  { 'a', new Tuple<int, int>(0, -1) },
                  { 's', new Tuple<int, int>(1, 0) },
                  { 'd', new Tuple<int, int>(0, 1)} };

                Tuple<int, int> topleft = new Tuple<int, int>(0, 0);
                Tuple<int, int> bottomright = new Tuple<int, int>(0, 0);
                
                addStructures(topleft, bottomright);

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        m[i + shrine_m][j + shrine_n] = shr.m[i][j];
                    }
                }
            }
        }

        */

        /*
        public List<Terrain> adjacents(List<List<Terrain>> m, int a, int b)
        {
            List < Terrain > adj = new List<Terrain>();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i != 1 && j != 1)
                    {
                        try
                        {
                            adj.Add(m[i + a][j + b]);
                        }
                        catch (System.ArgumentOutOfRangeException e)
                        {
                            continue; // do nothing
                        }
                    }
                }
            }
            return adj;
        }
        */

        public void addStructures(Tuple<int,int> topleft, Tuple<int, int> bottomright)
        {
            // int row_num = topleft / 22;
            // int row_col = bottomright / 22;

        }

        public Terrain[,] adjacents(List<List<Terrain>> m, int a, int b)
        {
            Terrain[,] adjacents = new Terrain[3, 3];
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    try
                    {
                        if (i != 1 && j != 1)
                            adjacents[i, j] = m[i + a][j + b];
                    }
                    catch (System.IndexOutOfRangeException e)
                    {
                        // do nothing
                    }
                }
            }
            return adjacents;
        }
    }
}

