using System;
using System.Collections.Generic;


namespace Terminus
{
    class Overworld : Map
    {
        OverworldFactory o = new OverworldFactory();
        Random r = new Random();
        public Overworld()
        {
            Generate();
        }

        public override void Generate()
        {
            for (int i=0;i<11;i++)
            {
                m.Add(new List<Terrain>());
                for (int j=0;j<11;j++)
                {
                    m[i].Add(o.GiveTerrain("Grass"));
                }
            }

            // Random r = new Random();

            for (int i=0;i<11;i++)
            {
                if (r.Next()%2==0)
                {
                    m[0][i] = o.GiveTerrain("Forest");
                    m[i][0] = o.GiveTerrain("Lake");
                    m[i][10] = o.GiveTerrain("Mountain");
                    m[10][0] = o.GiveTerrain("Desert");
                }
            }
        }

        public void midPoint(int dim)
        {
            // Random r = new Random();
            Double d = r.NextDouble() * 2 - 1;
            
            // generate the map corner values
            int t_left = r.Next(0, Terrain.terrainList.Count);
            int t_right = r.Next(0, Terrain.terrainList.Count);
            int b_left = r.Next(0, Terrain.terrainList.Count);
            int b_right = r.Next(0, Terrain.terrainList.Count);

            // initialize the map array

            Terrain[][] newMap = new Terrain[dim][];
            for (int i=0; i< dim; i++)
            {
                newMap[i] = new Terrain[dim];
            }

            // assign corner values to map
            newMap[0][0] = o.GiveTerrain(Terrain.terrainList[t_left]);
            newMap[0][dim - 1] = o.GiveTerrain(Terrain.terrainList[t_right]);
            newMap[dim - 1][0] = o.GiveTerrain(Terrain.terrainList[b_left]);
            newMap[dim - 1][dim - 1] = o.GiveTerrain(Terrain.terrainList[b_right]);

            // Console.WriteLine(newMap[0][0]);
            // Console.WriteLine(newMap[0][dim - 1]);
            // Console.WriteLine(newMap[dim - 1][0]);
            // Console.WriteLine(newMap[dim - 1][dim - 1]);

        }

        public void midPoint(int t_left, int t_right, int b_left, int b_right, Double dec)
        {

        }

        private Terrain getRandomTerrain(int i, int j)
        {
            // Random r = new Random();
            if (r.NextDouble() > 0.1) // return same type
            {
                List<Terrain> adj = adjacents(m, i, j);
                // Console.WriteLine(adj[r.Next(0, adj.Count)]);
                return adj[r.Next(0,adj.Count)];
            }
            else // return random
            {
                // Console.WriteLine(o.GiveTerrain(Terrain.terrainList[r.Next(0, Terrain.terrainList.Count)]));
                return o.GiveTerrain(Terrain.terrainList[r.Next(0, Terrain.terrainList.Count)]);
            }
        }
        
        public override void Grow(char d)
        {
            // Random r = new Random();
            int s = Terrain.terrainList.Count;
            for (int l = 0; l < 22; l++)
            {
                switch (d)
                {
                    case 'd': // east
                        for (int i = 0; i < m.Count; i++)
                            m[i].Insert(m[i].Count, getRandomTerrain(i, m[0].Count - 1));
                        break;
                    case 'w': // north
                        
                        m.Insert(0, new List<Terrain>());
                        for (int i = 0; i < m[1].Count; i++)
                            m[0].Add(getRandomTerrain(1, i));
                        break;
                    case 'a': // west
                        for (int i = 0; i < m.Count; i++)
                            m[i].Insert(0, getRandomTerrain(i, 1));
                        break;
                    case 's': // south
                        m.Insert(m.Count, new List<Terrain>());
                        for (int i = 0; i < m[0].Count; i++)
                            m[m.Count - 1].Add(getRandomTerrain(m.Count - 1, i));
                        break;
                    default:
                        break;
                }

                if (d =='d' && r.NextDouble()>0.8)
                {
                    int shrine_m = r.Next(4, m.Count-4);
                    int shrine_n = r.Next(m[1].Count-18, m[1].Count-5);

                    Shrine shr = new Shrine();

                    for (int i=0;i<3;i++)
                    {
                        for (int j=0;i<3;j++)
                        {
                            m[i + shrine_m][j + shrine_n] = shr.m[i][j];
                        }
                    }
                }
            }
        }

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

        /*
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
        */
    }
}

