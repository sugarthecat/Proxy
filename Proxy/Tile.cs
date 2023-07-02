using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Tile
    {
        protected Texture2D texture;
        private Rectangle position;
        protected string name;
        protected string terrainType;
        public Tile()
        {
            texture = Assets.GetTexture2D("banner");
            terrainType = "tile";
            name = "tile";
        }
        public Tile(Texture2D texture)
        {
            this.texture = texture;
            terrainType = "tile";
            name = "tile";
        }
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        public void setPosition(Rectangle drawPosition)
        {
            position = drawPosition;
        }
        public string getTerrainType()
        {
            return terrainType;
        }
        public bool containsPoint(Point point)
        {
            return position.Contains(point);
        }
        public string getName() { return name; }
    }
}
