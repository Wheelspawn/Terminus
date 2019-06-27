using System;
using System.Collections.Generic;

namespace Terminus
{
    class OverworldFactory : TerrainFactory
    {
        public OverworldFactory() {}

        public Terrain GiveRandTerrain()
        {
            Random r = new Random();
            List<String> terrains = new List<String> { "Lake", "Grass", "Desert", "Forest", "Mountain" };
            return GiveTerrain(terrains[r.Next(terrains.Count)]);
        }

        public override Terrain GiveTerrain(string name)
        {
            switch (name)
            {
                case "Lake":
                    return new Lake();
                case "Grass":
                    return new Grass();
                case "Desert":
                    return new Desert();
                case "Forest":
                    return new Forest();
                case "Mountain":
                    return new Mountain();
                case "Altar":
                    return new Altar();
                default:
                    return new Grass();
            }
        }

        public Terrain GiveTerrain(string name, string graphic)
        {
            switch (name)
            {
                case "Wall":
                    return new Wall(graphic);
                default:
                    return new Grass();
            }
        }
    }
}

