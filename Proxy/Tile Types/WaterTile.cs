using GameProject;
using Microsoft.Xna.Framework;

namespace Proxy.Tile_Types
{
    internal class WaterTile : Tile
    {
        public WaterTile(Point position) : base(Assets.GetTexture2D("water"), position)
        {
            name = "Open Seas";
        }
    }
}