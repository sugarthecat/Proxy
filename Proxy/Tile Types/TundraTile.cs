using GameProject;
using Microsoft.Xna.Framework;

namespace Proxy.Tile_Types
{
    internal class TundraTile : LandTile
    {
        public TundraTile(Point position) : base(Assets.GetTexture2D("tundra"), position)
        {
            terrainType = "tundra";
        }
    }
}