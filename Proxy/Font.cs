using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Font
    {
        public Dictionary<string, Texture2D> characterTextures;
        private string supportedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private Texture2D defaultCharacter;
        public Font(string addr, ContentManager content)
        {
            defaultCharacter = content.Load<Texture2D>(addr + "/default");
            characterTextures = new Dictionary<string, Texture2D>();
            for (int i = 0; i < supportedCharacters.Length; i++)
            {
                try
                {
                    characterTextures.Add(supportedCharacters[i] + "", content.Load<Texture2D>(addr + "/" + supportedCharacters[i]));
                }
                catch
                {
                    characterTextures.Add(supportedCharacters[i] + "", defaultCharacter);
                }
            }
        }
        public void DrawText(SpriteBatch spriteBatch, string textToDisplay, Rectangle textArea)
        {

            int newWidth = textArea.Width;
            int newHeight = textArea.Height;
            int xOffset = 0;
            int yOffset = 0;


    
            if (newWidth * 100 * textToDisplay.Length < newHeight * 64)
            {
                newWidth = (int)(newHeight / 100d * 64d * textToDisplay.Length);
                xOffset = (textArea.Width - newWidth) / 2;
            }
            else if (newWidth * 100 * textToDisplay.Length > newHeight * 64)
            {
                newHeight = (int)(newWidth * 100d / 64d / textToDisplay.Length);
                yOffset = (textArea.Height - newHeight) / 2;
            }

            Rectangle displayArea = new Rectangle(textArea.X + xOffset, textArea.Y + yOffset, newWidth, newHeight);

            
            for (int i = 0; i < textToDisplay.Length; i++)
            {
                if (characterTextures.ContainsKey(textToDisplay[i] + ""))
                {
                    Rectangle textRectangle = new Rectangle(displayArea.X + displayArea.Width / textToDisplay.Length * i, displayArea.Y, (int)((double)displayArea.Width / textToDisplay.Length), displayArea.Height);
                    spriteBatch.Draw(characterTextures[textToDisplay[i] + ""], textRectangle, Color.White);
                }
            }
        }
    }
}
