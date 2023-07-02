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
        public TileGUI(Tile selectedTile)
        {
            AddGuiElement(new GUIElement(Assets.GetTexture2D("background"), new Rectangle(10, 10, 300, 200)));
            AddGuiElement(new TextArea(new Rectangle(40, 30, 240, 40), Assets.getFont(), selectedTile.getName().ToLower()));
            AddGuiElement(new TextArea(new Rectangle(40, 80, 240, 50), Assets.getFont(), selectedTile.getTerrainType().ToLower()));
        }
    }
}