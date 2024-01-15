using GameProject;
using Microsoft.Xna.Framework;

namespace Proxy.Tile_Types
{
    internal class MountainTile : LandTile
    {
        public MountainTile(Point position) : base(Assets.GetTexture2D("mountains"), position)
        {
            terrainType = "mountain";
        }
    }
}