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
        private GUI subGUI;
        public WorldGUI()
        {

        }
        public void ClearSubGui()
        {
            subGUI = null;
            selectedTile = null;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if(selectedTile == null)
            {
                World.Draw(spriteBatch);
            }
            else
            {
                World.Draw(spriteBatch, selectedTile);
            }
            if(subGUI != null)
            {
                subGUI.Draw(spriteBatch);
            }
            base.Draw(spriteBatch);
        }
        public void setSubGUI(GUI subgui)
        {
            this.subGUI = subgui;
        }

        public override bool HandleClick(Point clickPoint)
        {   
            
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].HandleClick(clickPoint))
                {
                    return true;
                }
            }
            if(subGUI != null)
            {
                if (subGUI.HandleClick(clickPoint))
                {
                    return true;
                }
            }
            selectedTile = World.getTileAtPosition(clickPoint);
            
            if (selectedTile != null)
            {
                if(selectedTile is LandTile)
                {
                    subGUI = new TileGUI((LandTile)selectedTile,this);
                    return true;
                }
                else
                {
                    subGUI = null;
                }
            }
            return false;
        }
    }
}