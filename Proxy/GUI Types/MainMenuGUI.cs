using GameProject;
using Proxy.GUI_Element_Types;

namespace Proxy
{
    internal class MainMenuGUI : ScalingGUI
    {
        public MainMenuGUI() : base(800, 900)
        {
            AddGuiElement(new GUIElement(Assets.GetTexture2D("banner"),
              new Microsoft.Xna.Framework.Rectangle(0, 50, 800, 400)));

            AddGuiElement(new Button(
                    "load",
                    new Microsoft.Xna.Framework.Rectangle(410, 500, 300, 150)));

            AddGuiElement(new Button(
                    "new-game",
                    new Microsoft.Xna.Framework.Rectangle(90, 500, 300, 150),
                    delegate { Game1.instance.NavigateToMenu("world"); }));

            AddGuiElement(new Button(
                    "exit",
              new Microsoft.Xna.Framework.Rectangle(300, 790, 200, 100),
              delegate { Game1.instance.Exit(); }));

            AddGuiElement(new Button(
                    "settings",
              new Microsoft.Xna.Framework.Rectangle(300, 680, 200, 100),
              delegate { Game1.instance.ToggleSettings(); }));
        }
    }
}