using System;

namespace Terminus
{
    abstract class TerrainFactory
    {
        public TerrainFactory() {}
        public abstract Terrain GiveTerrain(string name);
    }
}

