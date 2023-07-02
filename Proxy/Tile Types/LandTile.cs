using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tile_Types
{
    internal class LandTile : Tile
    {
        public LandTile(Texture2D tile) : base(tile)
        {
            generateName();
        }
        private void generateName()
        {
            Random random = new Random();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string consonants = "bcdfghjklmnprstvw";
            string vowels = "aeiou";
            //Algorithm generates base as consonant-vowel-consonant-vowel-consonant where any of them can be pairs
            // think l/o/nd/o/n, m/o/sc/o/w, p/a/r/i/s, b/e/rl/i/n
            name = NameGenerator.getNewName(this);
        }
        public void drawCountry()
        {
              
        }
    }
}
