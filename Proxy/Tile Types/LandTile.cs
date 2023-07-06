using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using GameProject;

namespace Proxy.Tile_Types
{
    internal class LandTile : Tile
    {
        private Country country;
        protected int grainProduction;
        protected int population;
        public LandTile(Texture2D tile, Point position) : base(tile, position)
        {
            generateName();
        }
        public void setPopulation(int population)
        {
            this.population = population;
        }
        public int getPopulation() { return this.population; }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (isBorderingEnemy())
            {
                spriteBatch.Draw(Assets.GetTexture2D("rect"), getPosition(), getCountry().GetBorderColor());
            }
            else
            {
                spriteBatch.Draw(Assets.GetTexture2D("rect"), getPosition(), getCountry().GetColor());
            }
        }
        protected bool isBorderingEnemy()
        {
            for (int i = 0; i < borderingTiles.Length; i++)
            {
                if (borderingTiles[i] is LandTile && ((LandTile)borderingTiles[i]).getCountry() != getCountry())
                {
                    return true;
                }
            }
            return false;
        }
        private void generateName()
        {
            //Algorithm generates base as consonant-vowel-consonant-vowel-consonant where any of them can be pairs
            // think l/o/nd/o/n, m/o/sc/o/w, p/a/r/i/s, b/e/rl/i/n
            name = NameGenerator.getNewName(this);
        }
        public Country getCountry()
        {
            return country;
        }
        public bool isCapital()
        {
            return (country.GetCapital() == this);
        }
        public void setCountry(Country country)
        {
            if(this.country == country) return;
            if(this.country != null) {
                this.country.RemoveTile(this);
            }
            this.country = country;
            country.AddTile(this);
        }
        public void drawCountry()
        {

        }
    }
}
