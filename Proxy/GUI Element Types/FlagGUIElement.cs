using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.GUI_Element_Types
{
    internal class FlagGUIElement : GUIElement
    {
        Flag flag;
        public FlagGUIElement(Flag flag, Rectangle rect): base(Assets.GetTexture2D("rect"), rect)
        {
            this.flag = flag;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.GetTexture2D("rect"), position, flag.GetBaseColor());
            for(int i = 0; i<flag.GetElementCount(); i++)
            {
                flag.GetElement(i).Draw(spriteBatch, position);
            }
        }
    }
}
