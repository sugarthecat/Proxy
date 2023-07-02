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
    internal class WorldGUI : GUI
    {
        private Tile selectedTile;
        private GUI tileGUI;
        public WorldGUI()
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Font f = Assets.getFont();
            World.draw(spriteBatch);
            if(tileGUI != null)
            {
                tileGUI.Draw(spriteBatch);
            }
            base.Draw(spriteBatch);
        }
        public override void HandleClick(Point clickPoint)
        {   
            
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].HandleClick(clickPoint))
                {
                    return;
                }
            }
            selectedTile = World.getTileAtPosition(clickPoint);
            
            if (selectedTile != null)
            {
                if(selectedTile is LandTile)
                {
                    tileGUI = new TileGUI(selectedTile);
                }
                else
                {
                    tileGUI = null;
                }
            }
        }
    }
}