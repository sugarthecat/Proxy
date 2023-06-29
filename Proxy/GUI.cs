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
    public class GUI
    {
        private List<GUIElement> elements;
        public GUI() { 
            elements = new List<GUIElement>();
        }
        public void addGuiElement(GUIElement element)
        {
            elements.Add(element);
        }
        public void removeElement(GUIElement element)
        {
            elements.Remove(element);
        }
        public GUIElement getElement(int index) { 
            return elements[index];
        }
        public virtual void draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].draw(spriteBatch);
            }
        }
        public void handleClick(Point clickPoint) { 
            for(int i = 0; i< elements.Count; i++) {
                elements[i].handleClick(clickPoint);
            }
        }
    }
}
