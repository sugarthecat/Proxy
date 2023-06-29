using GameProject;
using Microsoft.Xna.Framework.Graphics;
using Proxy.GUI_Element_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class WorldGUI : GUI
    {
        public WorldGUI()
        {
        }
        public override void draw(SpriteBatch spriteBatch)
        {
            World.draw(spriteBatch);
            base.draw(spriteBatch);
        }
    }
}