using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Proxy
{
    public class GUI
    {
        protected List<GUIElement> elements;

        public GUI()
        {
            elements = new List<GUIElement>();
        }

        public void ResetElements()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].RevertToOriginalSize();
            }
        }
        
        public void AddGuiElement(GUIElement element)
        {
            elements.Add(element);
        }

        public void RemoveGuiElement(GUIElement element)
        {
            elements.Remove(element);
        }

        public GUIElement GetElement(int index)
        {
            return elements[index];
        }

        public void RemoveAllGuiElements()
        {
            elements.Clear();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Draw(spriteBatch);
            }
        }

        public virtual bool HandleClick(Point clickPoint)
        {
            bool activated = false;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].HandleClick(clickPoint))
                {
                    activated = true;
                };
            }
            return activated;
        }

        public void Translate(int x, int y)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Translate(x, y);
            }
        }

        public void Scale(double x, double y)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Scale(x, y);
            }
        }

        protected void ScaleGUIToFit(int width, int height)
        {
            double widthRatio = (double)Game1.GetScreenWidth() / width;
            double heightRatio = (double)Game1.GetScreenHeight() / height;
            int xoffset = 0;
            int yoffset = 0;
            if (widthRatio > heightRatio)
            {
                xoffset = (int)((widthRatio - heightRatio) * width / 2);
                widthRatio = heightRatio;
            }
            else
            {
                yoffset = (int)((heightRatio - widthRatio) * width / 2);
                heightRatio = widthRatio;
            }
            Scale(widthRatio, heightRatio);
            Translate(xoffset, yoffset);
        }
        protected void ScaleGUI(int width, int height)
        {
            double widthRatio = (double)Game1.GetScreenWidth() / width;
            double heightRatio = (double)Game1.GetScreenHeight() / height;
            Scale(widthRatio, heightRatio);
        }
    }
}