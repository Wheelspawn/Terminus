using System;
using System.Collections.Generic;

namespace Terminus
{
    interface ITerrain
    {
        string Graphic { get; set; }
        int ID  { get; set; }
        bool Impassable { get; set; }
        bool isImpassable();
        bool isOccupied();
    }
}

