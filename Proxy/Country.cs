using Microsoft.Xna.Framework;
using Proxy.Tile_Types;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Country
    {
        private string name;
        private LandTile capital;
        private List<LandTile> territory;
        private Color color;
        private Color borderColor;
        private int tileCount = 0;
        public Country(string name)
        {
            territory = new List<LandTile>();
            this.name = name;
            Random random = new Random();
            borderColor = new Color(random.Next(100, 255), random.Next(100, 255), random.Next(100, 255));
            color = borderColor * 0.3f;
        }
        public int GetPopulation()
        {
            int population = 0;
            foreach (LandTile tile in territory)
            {
                population+=tile.getPopulation();
            }
            return population;
        }
        public int GetTileCount()
        {
            return territory.Count;
        }
        public void AddTile(LandTile tile)
        {
            territory.Add(tile);
        }
        public void RemoveTile(LandTile tile)
        {
            territory.Remove(tile);
        }
        public LandTile GetCapital()
        {
            return capital;
        }
        public void SetCapital(LandTile capital)
        {
            this.capital = capital;
        }
        public Color GetColor()
        {
            return color;
        }
        public Color GetBorderColor()
        {
            return borderColor;
        }
        public string GetName()
        {
            return name;
        }
    }
}
