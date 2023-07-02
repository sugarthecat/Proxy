using GameProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tile_Types
{
    internal class WaterTile : Tile
    {

        public WaterTile() : base(Assets.GetTexture2D("water")){
            name = "Open Seas";
        }
    }
}
