using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Proxy.GUI_Element_Types
{
    public class Button : GUIElement
    {
        public Button(string buttonName, Rectangle position) : base(Assets.GetTexture2D(buttonName + "-button"), position)
        {
        }

        public Button(string buttonName, Rectangle position, Action action) : base(Assets.GetTexture2D(buttonName + "-button"), position, action)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            MouseState mouseState = Mouse.GetState();
            if (position.Contains(mouseState.X, mouseState.Y))
            {
                spriteBatch.Draw(texture, position, new Rectangle(0, 0, texture.Width / 2, texture.Height), Color.White);
            }
            else
            {
                spriteBatch.Draw(texture, position, new Rectangle(texture.Width / 2, 0, texture.Width / 2, texture.Height), Color.White);
            }
        }
    }
}