﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Proxy
{
    public class Font
    {
        public Dictionary<char, Texture2D> characterTextures;
        private Texture2D defaultCharacter;
        private string directory;

        public Font(string addr, ContentManager content)
        {
            directory = addr;
            defaultCharacter = content.Load<Texture2D>(addr + "/default");
            characterTextures = new Dictionary<char, Texture2D>();
            string basicCharacters = "abcdefghijklmnopqrstuvwxyz1234567890";
            for (int i = 0; i < basicCharacters.Length; i++)
            {
                loadCharacter(basicCharacters[i], basicCharacters[i] + "", content);
            }
            string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < capitalLetters.Length; i++)
            {
                loadCharacter(capitalLetters[i], "capital" + basicCharacters[i], content);
            }
            loadCharacter(',', "comma", content);
            loadCharacter(':', "colon", content);
            loadCharacter('/', "slash", content);
        }

        private void loadCharacter(char character, string addr, ContentManager content)
        {
            try
            {
                characterTextures.Add(character, content.Load<Texture2D>(directory + "/" + addr));
            }
            catch
            {
                characterTextures.Add(character, defaultCharacter);
            }
        }

        public void DrawText(SpriteBatch spriteBatch, string textToDisplay, Rectangle textArea)
        {
            int width = textArea.Width;
            int height = textArea.Height;
            int xOffset = 0;
            int yOffset = 0;
            int widthFactor = 0;
            if (textToDisplay.Length < 1)
            {
                return;
            }
            int heightFactor = characterTextures[textToDisplay[0]].Height;
            for (int i = 0; i < textToDisplay.Length; i++)
            {
                if (characterTextures.ContainsKey(textToDisplay[i]))
                {
                    widthFactor += characterTextures[textToDisplay[i]].Width;
                }
                else
                {
                    widthFactor += 100;
                }
            }

            int theoreticNewWidth = (int)(widthFactor * height / (double)heightFactor);
            int theoreticNewHeight = (int)(heightFactor * width / (double)widthFactor);
            if (theoreticNewWidth < width)
            {
                width = theoreticNewWidth;
                xOffset = (textArea.Width - width) / 2;
            }
            else if (theoreticNewHeight < height)
            {
                height = theoreticNewHeight;
                yOffset = (textArea.Height - height) / 2;
            }
            Rectangle displayArea = new Rectangle(textArea.X + xOffset, textArea.Y + yOffset, width, height);

            int widthOn = 0;
            for (int i = 0; i < textToDisplay.Length; i++)
            {
                if (characterTextures.ContainsKey(textToDisplay[i]))
                {
                    Rectangle textRectangle = new Rectangle(
                        displayArea.X + widthOn,
                        displayArea.Y,
                        (int)((double)displayArea.Width / widthFactor * characterTextures[textToDisplay[i]].Width),
                        displayArea.Height
                        );
                    spriteBatch.Draw(characterTextures[textToDisplay[i]], textRectangle, Color.White);
                    widthOn += textRectangle.Width;
                }
                else
                {
                    widthOn += (int)((double)displayArea.Width / widthFactor * 100);
                }
            }
        }
    }
}