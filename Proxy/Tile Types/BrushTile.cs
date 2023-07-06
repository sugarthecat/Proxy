using GameProject;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tile_Types
{
    internal class BrushTile : LandTile
    {
        public BrushTile(Point position) : base(Assets.GetTexture2D("brushland"), position)
        {
            terrainType = "brushland";
        }
    }
}
