using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Proxy.GUI_Element_Types
{
    public class TextArea : GUIElement
    {
        private Font font;
        private string text;

        public TextArea(Rectangle position, Font font, string text) : base(Assets.GetTexture2D("background"), position)
        {
            this.font = font;
            this.text = text;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            font.DrawText(spriteBatch, text, position);
        }
    }
}