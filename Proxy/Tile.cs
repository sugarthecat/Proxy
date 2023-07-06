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
        private Point mapPosition;
        protected Tile[] borderingTiles;
        public Tile(Texture2D texture, Point mapPosition)
        {
            this.texture = texture;
            terrainType = "tile";
            name = "tile";
            this.mapPosition = mapPosition;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        public void setPosition(Rectangle drawPosition)
        {
            position = drawPosition;
        }
        public void setBorderingTiles(Tile[] borderingTiles)
        {
            this.borderingTiles = borderingTiles;
        }
        public Rectangle getPosition()
        {
            return position;
        }
        public Point getPointPosition()
        {
            return mapPosition;
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
