using GameProject;
using Microsoft.Xna.Framework;
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
        public PlainsTile(Point position) : base(Assets.GetTexture2D("plains"), position)
        {
            terrainType = "grasslands";
        }
    }
}
