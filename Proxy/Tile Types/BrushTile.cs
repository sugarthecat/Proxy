using GameProject;
using Microsoft.Xna.Framework;

namespace Proxy.Tile_Types
{
    internal class BrushTile : LandTile
    {
        public BrushTile(Point position) : base(Assets.GetTexture2D("brushland"), position)
        {
            terrainType = "brushland";
        }
    }
}