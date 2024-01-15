using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Proxy.GUI_Element_Types;
using Proxy.Tile_Types;

namespace Proxy
{
    internal class WorldGUI : ScalingGUI
    {
        private Tile selectedTile;
        private GUI subGUI;

        public WorldGUI() : base(1000, 1000)
        {
            AddGuiElement(new GUIElement(Assets.GetTexture2D("rect"),new Rectangle(0,0,1000,100), Color.Black));
            AddGuiElement(new AdaptiveTextArea(new Rectangle(400, 0, 200, 100), Assets.getFont(), delegate () { return World.getCurrentTime(); }));
        }
        public void ClearSubGui()
        {
            subGUI = null;
            selectedTile = null;
        }
        public override void RescaleElements()
        {
            ResetElements();
            ScaleGUI(1000, 1000);
            if(subGUI != null)
            {
                subGUI.ResetElements();
                subGUI.Translate(0,(int)(Game1.GetScreenHeight()*0.1d));
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (selectedTile == null)
            {
                World.Draw(spriteBatch);
            }
            else
            {
                World.Draw(spriteBatch, selectedTile);
            }
            if (subGUI != null)
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
            if (subGUI != null)
            {
                if (subGUI.HandleClick(clickPoint))
                {
                    return true;
                }
            }
            selectedTile = World.getTileAtPosition(clickPoint);

            if (selectedTile != null)
            {
                if (selectedTile is LandTile)
                {
                    subGUI = new TileGUI((LandTile)selectedTile, this);
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