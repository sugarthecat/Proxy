using GameProject;
using Proxy.GUI_Element_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class MainMenuGUI : GUI
    {
        public MainMenuGUI()
        {
            addGuiElement(new GUIElement(Assets.GetTexture2D("banner"),
              new Microsoft.Xna.Framework.Rectangle(200, 50,800, 400)));

            addGuiElement(new Button(
                    "load",
                    new Microsoft.Xna.Framework.Rectangle(600, 500, 300, 150)));

            addGuiElement(new Button(
                    "new-game",
                    new Microsoft.Xna.Framework.Rectangle(300, 500, 300, 150),
                    delegate { Game1.instance.NavigateToMenu("world"); }));


            addGuiElement(new Button(
                    "exit",
              new Microsoft.Xna.Framework.Rectangle(500, 800, 200, 100),
              delegate { Game1.instance.Exit(); }));

            addGuiElement(new Button(
                    "settings",
              new Microsoft.Xna.Framework.Rectangle(500, 700, 200, 100),
              delegate { Game1.instance.toggleSettings(); }));
        }
    }
}