using GameProject;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tile_Types
{
    internal class TundraTile : LandTile
    {
        public TundraTile() : base(Assets.GetTexture2D("tundra"))
        {
            terrainType = "tundra";
        }
    }
}
