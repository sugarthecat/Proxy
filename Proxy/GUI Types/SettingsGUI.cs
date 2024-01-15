using GameProject;
using Proxy.GUI_Element_Types;

namespace Proxy
{
    internal class SettingsGUI : ScalingGUI
    {
        public SettingsGUI() : base(800, 900)
        {
            AddGuiElement(new GUIElement(Assets.GetTexture2D("banner"),
              new Microsoft.Xna.Framework.Rectangle(100, 50, 600, 300)));
            AddGuiElement(new Button("return",
              new Microsoft.Xna.Framework.Rectangle(300, 400, 200, 90),
              delegate { Game1.instance.ToggleSettings(); }));

            AddGuiElement(new Button("toggle-fullscreen",
              new Microsoft.Xna.Framework.Rectangle(300, 500, 200, 90),
              delegate { Game1.instance.ToggleFullscreen(); }));

            AddGuiElement(new Button("quit-game",
              new Microsoft.Xna.Framework.Rectangle(300, 600, 200, 90),
              delegate { Game1.instance.Exit(); }));
        }
    }
}