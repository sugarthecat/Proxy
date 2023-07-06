using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Proxy.GUI_Element_Types;
using Proxy.Tile_Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Proxy
{
    internal class TileGUI : GUI
    {
        public TileGUI(LandTile selectedTile, WorldGUI worldGUI)
        {
            AddGuiElement(new GUIElement(Assets.GetTexture2D("background"), new Rectangle(10, 10, 300, 250)));
            AddGuiElement(new TextArea(new Rectangle(40, 30, 240, 50), Assets.getFont(), selectedTile.getName().ToLower()));
            AddGuiElement(new TextArea(new Rectangle(40, 90, 240, 30), Assets.getFont(), selectedTile.getTerrainType().ToLower()));
            if (selectedTile is LandTile && ((LandTile)selectedTile).getCountry() != null)
            {
                AddGuiElement(new TextArea(new Rectangle(40, 130, 240, 30), Assets.getFont(), ((LandTile)selectedTile).getCountry().GetName().ToLower()));
                AddGuiElement(new GUIElement(Assets.GetTexture2D("rect"), new Rectangle(20, 130, 25, 25), ((LandTile)selectedTile).getCountry().GetBorderColor()));
            }
            AddGuiElement(new TextArea(new Rectangle(40, 170, 240, 30), Assets.getFont(), "Population " + ((LandTile)selectedTile).getPopulation().ToString()));
            AddGuiElement(new Button("x", new Rectangle(10, 10, 30, 30), delegate { worldGUI.ClearSubGui(); }));
            AddGuiElement(new Button("country", new Rectangle(100, 210, 100, 40), delegate { worldGUI.setSubGUI(new CountryGUI(selectedTile.getCountry(), worldGUI)); }));
        }
    }
}