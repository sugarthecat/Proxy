using GameProject;
using Microsoft.Xna.Framework;
using Proxy.GUI_Element_Types;

namespace Proxy
{
    internal class CountryGUI : GUI
    {
        public CountryGUI(Country selectedCountry, WorldGUI worldGUI)
        {
            AddGuiElement(new GUIElement(Assets.GetTexture2D("background"), new Rectangle(10, 10, 400, 300)));
            /*
            AddGuiElement(new GUIElement(Assets.GetTexture2D("rect"), new Rectangle(20, 30, 40, 40), selectedCountry.GetBorderColor()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("rect"), new Rectangle(350, 30, 40, 40), selectedCountry.GetBorderColor()));
            AddGuiElement(new TextArea(new Rectangle(70, 30, 280, 50), Assets.getFont(), selectedCountry.GetName()));
            AddGuiElement(new TextArea(new Rectangle(40, 90, 340, 30), Assets.getFont(), "Population: " + string.Format("{0:#,0}", selectedCountry.GetPopulation())));
            AddGuiElement(new TextArea(new Rectangle(40, 130, 340, 30), Assets.getFont(), "Tile area: " + string.Format("{0:#,0}", selectedCountry.GetTileCount())));
            AddGuiElement(new TextArea(new Rectangle(40, 170, 340, 30), Assets.getFont(), "Density: " + string.Format("{0:#,0}", selectedCountry.GetPopulation() / selectedCountry.GetTileCount())));
            AddGuiElement(new Button("x", new Rectangle(10, 10, 30, 30), delegate { worldGUI.ClearSubGui(); }));
            AddGuiElement(new Button("resources", new Rectangle(100, 220, 200, 70), delegate { worldGUI.setSubGUI(new ResourceGUI(selectedCountry.GetResourceCount(), worldGUI)); }));*/
            AddGuiElement(new FlagGUIElement(selectedCountry.GetFlag(), new Rectangle(40, 40, 340, 240)));
        }
    }
}