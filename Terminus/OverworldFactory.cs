using System;

namespace Terminus
{
    class OverworldFactory : TerrainFactory
    {
        public OverworldFactory() {}
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
                default:
                    return new Grass();
            }
        }
    }
}

