using GameProject;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tile_Types
{
    internal class ForestTile : LandTile
    {
        public ForestTile() : base(Assets.GetTexture2D("forest"))
        {
            terrainType = "forest";
        }
    }
}
