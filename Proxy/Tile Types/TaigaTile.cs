using GameProject;
using Microsoft.Xna.Framework;

namespace Proxy.Tile_Types
{
    internal class TaigaTile : LandTile
    {
        public TaigaTile(Point position) : base(Assets.GetTexture2D("taiga"), position)
        {
            terrainType = "taiga";
        }
    }
}