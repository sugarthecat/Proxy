using GameProject;
using Proxy.GUI_Element_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class SettingsGUI : GUI
    {
        public SettingsGUI()
        {
            addGuiElement(new GUIElement(Assets.GetTexture2D("banner"),
              new Microsoft.Xna.Framework.Rectangle(300, 50, 600,300)));
            addGuiElement(new Button("return",
              new Microsoft.Xna.Framework.Rectangle(500, 400, 200, 100),
              delegate { Game1.instance.toggleSettings(); }));

            addGuiElement(new Button("toggle-fullscreen",
              new Microsoft.Xna.Framework.Rectangle(500, 500, 200, 100),
              delegate { Game1.instance.toggleFullscreen(); }));
        }
    }
}