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
            AddGuiElement(new GUIElement(Assets.GetTexture2D("banner"),
              new Microsoft.Xna.Framework.Rectangle(200, 50,800, 400)));

            AddGuiElement(new Button(
                    "load",
                    new Microsoft.Xna.Framework.Rectangle(610, 500, 300, 150)));

            AddGuiElement(new Button(
                    "new-game",
                    new Microsoft.Xna.Framework.Rectangle(290, 500, 300, 150),
                    delegate { Game1.instance.NavigateToMenu("world"); }));


            AddGuiElement(new Button(
                    "exit",
              new Microsoft.Xna.Framework.Rectangle(500, 790, 200, 100),
              delegate { Game1.instance.Exit(); }));

            AddGuiElement(new Button(
                    "settings",
              new Microsoft.Xna.Framework.Rectangle(500, 680, 200, 100),
              delegate { Game1.instance.ToggleSettings(); }));
        }
    }
}