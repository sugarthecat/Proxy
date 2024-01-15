using GameProject;
using Microsoft.Xna.Framework;

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