using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameProject
{
    public static class Assets
    {
        public static Dictionary<string,Texture2D> textures;
        private static ContentManager content;

        public static void Setup(ContentManager contentManager)
        {
            content = contentManager;
            textures = new Dictionary<string,Texture2D>();
            LoadTextures();
        }

        public static void LoadTextures()
        {
            textures.Add("banner", content.Load<Texture2D>("assets/gui/banner"));

            textures.Add("brushland", content.Load<Texture2D>("assets/tiles/brushland"));
            textures.Add("jungle", content.Load<Texture2D>("assets/tiles/jungle"));
            textures.Add("plains", content.Load<Texture2D>("assets/tiles/plains"));
            textures.Add("taiga", content.Load<Texture2D>("assets/tiles/taiga"));
            textures.Add("water", content.Load<Texture2D>("assets/tiles/water"));
            textures.Add("forest", content.Load<Texture2D>("assets/tiles/forest"));
            textures.Add("tundra", content.Load<Texture2D>("assets/tiles/tundra"));
            textures.Add("desert", content.Load<Texture2D>("assets/tiles/desert"));
            textures.Add("mountains", content.Load<Texture2D>("assets/tiles/mountains"));
            loadButton("play");
            loadButton("exit");
            loadButton("load");
            loadButton("new-game");
            loadButton("toggle-fullscreen");
            loadButton("settings");
            loadButton("return");
        }
        public static void loadButton(string buttonName)
        {
            textures.Add(buttonName + "-button", content.Load<Texture2D>("assets/gui/" + buttonName + "-button"));
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