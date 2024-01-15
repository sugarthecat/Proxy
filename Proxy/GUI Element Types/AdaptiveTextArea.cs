using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Proxy.GUI_Element_Types
{
    public class AdaptiveTextArea : GUIElement
    {
        private Font font;
        private Func<string> textRetreiver;

        public AdaptiveTextArea(Rectangle position, Font font, Func<string> textFunc) : base(Assets.GetTexture2D("background"), position)
        {
            this.font = font;
            textRetreiver = textFunc;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            font.DrawText(spriteBatch, textRetreiver(), position);
        }
    }
}