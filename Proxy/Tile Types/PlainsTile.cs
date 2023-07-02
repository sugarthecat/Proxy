using GameProject;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tile_Types
{
    internal class PlainsTile : LandTile
    {
        public PlainsTile() : base(Assets.GetTexture2D("plains"))
        {
            terrainType = "grasslands";
        }
    }
}
