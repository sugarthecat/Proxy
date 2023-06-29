using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Proxy
{
    public class GUIElement
    {
        protected Rectangle position;
        protected Texture2D texture;
        protected Texture2D textureHover;
        protected Action activationAction;
        
        public GUIElement(Texture2D baseTexture, Rectangle elementPosition)
        {
            position = elementPosition;
            texture = baseTexture;
            textureHover = baseTexture;
            activationAction = delegate { };
        }
        public GUIElement(Texture2D baseTexture, Texture2D hoverTexture, Rectangle elementPosition)
        {

            position = elementPosition;
            texture = baseTexture;
            textureHover = hoverTexture;
            activationAction = delegate { };
        }
        public GUIElement(Texture2D baseTexture, Texture2D hoverTexture, Rectangle elementPosition, Action actionOnActivate)
        {

            position = elementPosition;
            texture = baseTexture;
            textureHover = hoverTexture;
            activationAction = actionOnActivate;
        }
        public GUIElement(Texture2D baseTexture, Rectangle elementPosition, Action actionOnActivate)
        {

            position = elementPosition;
            texture = baseTexture;
            textureHover = baseTexture;
            activationAction = actionOnActivate;
        }
        public virtual void draw(SpriteBatch spriteBatch)
        {
            MouseState mouseState = Mouse.GetState();
            if (position.Contains(mouseState.X,mouseState.Y))
            {
                spriteBatch.Draw(textureHover, position, Color.White);
            }
            else
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }
        public void handleClick(Point mousePoint) {
            if (position.Contains(mousePoint))
            {
                activationAction();
            }
        }
    }
}
