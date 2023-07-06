using GameProject;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tile_Types
{
    internal class ForestTile : LandTile
    {
        public ForestTile(Point position) : base(Assets.GetTexture2D("forest"), position)
        {
            terrainType = "forest";
        }
    }
}
