using GameProject;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tile_Types
{
    internal class WaterTile : Tile
    {

        public WaterTile(Point position) : base(Assets.GetTexture2D("water"), position){
            name = "Open Seas";
        }
    }
}
