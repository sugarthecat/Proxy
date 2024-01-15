using GameProject;
using Microsoft.Xna.Framework;
using Proxy.GUI_Element_Types;

namespace Proxy
{
    internal class ResourceGUI : GUI
    {
        public ResourceGUI(ResourceCount resourceCount, WorldGUI worldGUI)
        {
            AddGuiElement(new GUIElement(Assets.GetTexture2D("background"), new Rectangle(10, 10, 200, 545)));
            AddGuiElement(new Button("x", new Rectangle(10, 10, 30, 30), delegate { worldGUI.ClearSubGui(); }));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("oil"), new Rectangle(20, 50, 40, 40)));
            AddGuiElement(new TextArea(new Rectangle(70, 50, 120, 40), Assets.getFont(), resourceCount.oil.ToString()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("lumber"), new Rectangle(20, 100, 40, 40)));
            AddGuiElement(new TextArea(new Rectangle(70, 100, 120, 40), Assets.getFont(), resourceCount.lumber.ToString()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("food"), new Rectangle(20, 150, 40, 40)));
            AddGuiElement(new TextArea(new Rectangle(70, 150, 120, 40), Assets.getFont(), resourceCount.food.ToString()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("coal"), new Rectangle(20, 200, 40, 40)));
            AddGuiElement(new TextArea(new Rectangle(70, 200, 120, 40), Assets.getFont(), resourceCount.coal.ToString()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("bauxite"), new Rectangle(20, 250, 40, 40)));
            AddGuiElement(new TextArea(new Rectangle(70, 250, 120, 40), Assets.getFont(), resourceCount.bauxite.ToString()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("gold"), new Rectangle(20, 300, 40, 40)));
            AddGuiElement(new TextArea(new Rectangle(70, 300, 120, 40), Assets.getFont(), resourceCount.gold.ToString()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("rubber"), new Rectangle(20, 350, 40, 40)));
            AddGuiElement(new TextArea(new Rectangle(70, 350, 120, 40), Assets.getFont(), resourceCount.rubber.ToString()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("lithium"), new Rectangle(20, 400, 40, 40)));
            AddGuiElement(new TextArea(new Rectangle(70, 400, 120, 40), Assets.getFont(), resourceCount.lithium.ToString()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("uranium"), new Rectangle(20, 450, 40, 40)));
            AddGuiElement(new TextArea(new Rectangle(70, 450, 120, 40), Assets.getFont(), resourceCount.uranium.ToString()));
            AddGuiElement(new GUIElement(Assets.GetTexture2D("titanium"), new Rectangle(20, 500, 40, 40)));
            AddGuiElement(new TextArea(new Rectangle(70, 500, 120, 40), Assets.getFont(), resourceCount.titanium.ToString()));
        }
    }
}