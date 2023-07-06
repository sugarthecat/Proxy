using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Proxy;
using System.Collections.Generic;

namespace GameProject
{
    public static class Assets
    {
        public static Dictionary<string,Texture2D> textures;
        private static ContentManager content;
        private static Font pixelFont;
        public static void Setup(ContentManager contentManager)
        {
            content = contentManager;
            textures = new Dictionary<string,Texture2D>();
            LoadTextures();
        }

        public static void LoadTextures()
        {
            textures.Add("banner", content.Load<Texture2D>("assets/gui/banner"));

            loadTile("brushland");
            loadTile("jungle");
            loadTile("plains");
            loadTile("water");
            loadTile("taiga");
            loadTile("desert");
            loadTile("forest");
            loadTile("tundra");
            loadTile("mountains");
            textures.Add("background", content.Load<Texture2D>("assets/gui/background"));
            textures.Add("selected-tile-overlay", content.Load<Texture2D>("assets/gui/selected-tile-overlay"));
            textures.Add("rect", content.Load<Texture2D>("assets/solid-white-block"));
            pixelFont = new Font("assets/fonts/pixel",content);
            loadButton("play");
            loadButton("exit");
            loadButton("load");
            loadButton("new-game");
            loadButton("toggle-fullscreen");
            loadButton("settings");
            loadButton("return");
            loadButton("x");
            loadButton("country");
        }
        public static Font getFont()
        {
            return pixelFont;
        }
        public static void loadButton(string buttonName)
        {
            textures.Add(buttonName + "-button", content.Load<Texture2D>("assets/gui/" + buttonName + "-button"));
        }
        public static void loadTile(string tileName)
        {
            textures.Add(tileName, content.Load<Texture2D>("assets/tiles/" + tileName));
        }
        public static Texture2D GetTexture2D(string name)
        {
            return textures[name];
        }
        public static void LoadShaders(ContentManager content)
        {
            /*
            */
        }
    }
}