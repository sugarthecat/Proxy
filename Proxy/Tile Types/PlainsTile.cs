using GameProject;
using Microsoft.Xna.Framework;

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