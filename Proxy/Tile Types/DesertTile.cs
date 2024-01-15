using GameProject;
using Microsoft.Xna.Framework;

namespace Proxy.Tile_Types
{
    internal class DesertTile : LandTile
    {
        public DesertTile(Point position) : base(Assets.GetTexture2D("desert"), position)
        {
            terrainType = "desert";
        }
    }
}