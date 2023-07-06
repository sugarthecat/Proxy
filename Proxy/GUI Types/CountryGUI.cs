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
    internal class CountryGUI : GUI
    {
        public CountryGUI(Country selectedCountry, WorldGUI worldGUI)
        {
            AddGuiElement(new GUIElement(Assets.GetTexture2D("background"), new Rectangle(10, 10, 400, 300)));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("rect"), new Rectangle(20, 30, 40, 40), selectedCountry.GetBorderColor()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("rect"), new Rectangle(350, 30, 40, 40), selectedCountry.GetBorderColor()));
            AddGuiElement(new TextArea(new Rectangle(70, 30, 280, 50), Assets.getFont(), selectedCountry.GetName().ToLower()));

            AddGuiElement(new TextArea(new Rectangle(40, 90, 340, 30), Assets.getFont(), "Population " + selectedCountry.GetPopulation().ToString()));
            AddGuiElement(new TextArea(new Rectangle(40, 130, 340, 30), Assets.getFont(), "Tile area " + selectedCountry.GetTileCount().ToString()));
            AddGuiElement(new TextArea(new Rectangle(40, 170, 340, 30), Assets.getFont(), "Density " + (selectedCountry.GetPopulation()/selectedCountry.GetTileCount()).ToString()));
            AddGuiElement(new Button("x", new Rectangle(10, 10, 30, 30), delegate { worldGUI.ClearSubGui(); }));
        }
    }
}