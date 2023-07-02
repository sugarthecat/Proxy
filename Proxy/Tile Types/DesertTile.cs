using GameProject;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tile_Types
{
    internal class DesertTile : LandTile
    {
        public DesertTile() : base(Assets.GetTexture2D("desert"))
        {
            terrainType = "desert";
        }
    }
}
