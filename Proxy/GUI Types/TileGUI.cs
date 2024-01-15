using GameProject;
using Microsoft.Xna.Framework;
using Proxy.GUI_Element_Types;
using Proxy.Tile_Types;

namespace Proxy
{
    internal class TileGUI : GUI
    {
        public TileGUI(LandTile selectedTile, WorldGUI worldGUI)
        {
            AddGuiElement(new GUIElement(Assets.GetTexture2D("background"), new Rectangle(10, 10, 300, 250)));
            AddGuiElement(new TextArea(new Rectangle(40, 30, 240, 50), Assets.getFont(), selectedTile.getName()));
            AddGuiElement(new TextArea(new Rectangle(40, 90, 240, 30), Assets.getFont(), selectedTile.getTerrainType()));
            if (selectedTile is LandTile && selectedTile.getCountry() != null)
            {
                AddGuiElement(new TextArea(new Rectangle(40, 130, 240, 30), Assets.getFont(), selectedTile.getCountry().GetName()));
                AddGuiElement(new GUIElement(Assets.GetTexture2D("rect"), new Rectangle(20, 130, 25, 25), selectedTile.getCountry().GetBorderColor()));
            }
            AddGuiElement(new TextArea(new Rectangle(40, 170, 240, 30), Assets.getFont(), "Population: " + selectedTile.getPopulation().ToString()));
            AddGuiElement(new Button("x", new Rectangle(10, 10, 30, 30), delegate { worldGUI.ClearSubGui(); }));
            AddGuiElement(new Button("country", new Rectangle(35, 210, 100, 40), delegate { worldGUI.setSubGUI(new CountryGUI(selectedTile.getCountry(), worldGUI)); }));
            AddGuiElement(new Button("resources", new Rectangle(185, 210, 100, 40), delegate { worldGUI.setSubGUI(new ResourceGUI(selectedTile.getResourceCount(), worldGUI)); }));
        }
    }
}