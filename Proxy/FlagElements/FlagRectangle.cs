using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.FlagElements
{
    internal class FlagRectangle : FlagElement
    {
        Color color;
        Rectangle position;
        public FlagRectangle(Color color, Rectangle position) {
            this.color = color;
            this.position = position;
        }
        public override void Draw(SpriteBatch spriteBatch, Rectangle flagPosition) { 
            Rectangle newPosition = new Rectangle(flagPosition.X + position.X * flagPosition.Width / 12,flagPosition.Y + position.Y * flagPosition.Height / 12, (int)Math.Ceiling(flagPosition.Width*position.Width/12f), (int)Math.Ceiling(flagPosition.Height*position.Height/12f));
            spriteBatch.Draw(Assets.GetTexture2D("rect"), newPosition, color);
        }
    }
}
