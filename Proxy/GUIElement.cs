using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Proxy
{
    public class GUIElement
    {
        protected Rectangle position;
        private Rectangle originalPosition;
        protected Texture2D texture;
        protected Texture2D textureHover;
        protected Action activationAction;
        private Color color;

        public GUIElement(Texture2D baseTexture, Rectangle elementPosition)
        {
            position = elementPosition;
            originalPosition = elementPosition;
            texture = baseTexture;
            textureHover = baseTexture;
            activationAction = delegate { };
            color = Color.White;
        }

        public GUIElement(Texture2D baseTexture, Rectangle elementPosition, Color color)
        {
            position = elementPosition;
            originalPosition = elementPosition;
            texture = baseTexture;
            textureHover = baseTexture;
            activationAction = delegate { };
            this.color = color;
        }

        public GUIElement(Texture2D baseTexture, Texture2D hoverTexture, Rectangle elementPosition)
        {
            position = elementPosition;
            originalPosition = elementPosition;
            texture = baseTexture;
            textureHover = hoverTexture;
            activationAction = delegate { };
            color = Color.White;
        }

        public GUIElement(Texture2D baseTexture, Texture2D hoverTexture, Rectangle elementPosition, Action actionOnActivate)
        {
            position = elementPosition;
            originalPosition = elementPosition;
            texture = baseTexture;
            textureHover = hoverTexture;
            activationAction = actionOnActivate;
            color = Color.White;
        }

        public GUIElement(Texture2D baseTexture, Rectangle elementPosition, Action actionOnActivate)
        {
            position = elementPosition;
            originalPosition = elementPosition;
            texture = baseTexture;
            textureHover = baseTexture;
            activationAction = actionOnActivate;
            color = Color.White;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            MouseState mouseState = Mouse.GetState();
            if (position.Contains(mouseState.X, mouseState.Y))
            {
                spriteBatch.Draw(textureHover, position, color);
            }
            else
            {
                spriteBatch.Draw(texture, position, color);
            }
        }

        public bool HandleClick(Point mousePoint)
        {
            if (position.Contains(mousePoint))
            {
                activationAction();
                return true;
            }
            return false;
        }

        public void RevertToOriginalSize()
        {
            position = new Rectangle(originalPosition.X, originalPosition.Y, originalPosition.Width, originalPosition.Height);
        }

        public void Translate(int x, int y)
        {
            position.X += x;
            position.Y += y;
        }

        public void Scale(double x, double y)
        {
            position.X = (int)(x * position.X);
            position.Y = (int)(y * position.Y);
            position.Width = (int)(x * position.Width);
            position.Height = (int)(y * position.Height);
        }
    }
}