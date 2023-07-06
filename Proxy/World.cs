using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Proxy.Tile_Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal static class World
    {
        private static List<Country> countries;
        private static Tile[,] tileMap;
        private static string mapMode = "geography";
        private static int xOffset = 0;
        private static int yOffset = 0;
        private static double viewScale = 1;
        public static void Move(int x, int y)
        {
            xOffset += x;
            yOffset += y;
            if (xOffset < Game1.instance.GetScreenWidth() * (1d - viewScale))
            {
                xOffset = (int)(Game1.instance.GetScreenWidth() * (1d - viewScale));
            }
            if (yOffset < Game1.instance.GetScreenHeight() * (1d - viewScale))
            {
                yOffset = (int)(Game1.instance.GetScreenHeight() * (1d - viewScale));
            }
            if (xOffset > 0)
            {
                xOffset = 0;
            }
            if (yOffset > 0)
            {
                yOffset = 0;
            }
        }
        public static void Scale(int scaleFactor)
        {
            if (scaleFactor == 0)
            {
                return;
            }
            double previousWidth = viewScale + 0;
            double finalFactor = scaleFactor;
            finalFactor *= 0.01;
            if (scaleFactor > 0)
            {
                viewScale *= finalFactor;
            }
            else if (scaleFactor < 0)
            {
                viewScale /= Math.Abs(finalFactor);
            }
            if (viewScale < 1)
            {
                viewScale = 1;
            }
            double sizeDiff = (previousWidth - viewScale)/2;
            Move((int)(sizeDiff*Game1.instance.GetScreenWidth()), (int)(sizeDiff * Game1.instance.GetScreenHeight()));
        }
        public static void GenerateWorld()
        {
            Noise temperatureNoise = new Noise();
            float tempscale = 0.03f;
            Noise elevationNoise = new Noise();
            Noise elevationNoise2 = new Noise();
            float elevationScale = 0.08f;
            float elevationScale2 = 0.02f;
            Random generationRandom = new Random();
            tileMap = new Tile[200, 200];
            //generate terrain
            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for (int j = 0; j < tileMap.GetLength(1); j++)
                {
                    int worldHeight = tileMap.GetLength(1);
                    double density = 0;
                    double latitudeTemp = (double)(worldHeight / 2 - Math.Abs(j - worldHeight / 2));
                    latitudeTemp /= (double)worldHeight;
                    double noiseTemp = temperatureNoise.getPosition(((float)i) * tempscale, ((float)j) * tempscale);

                    double temperature = latitudeTemp + noiseTemp / 2;
                    double elevation = elevationNoise.getPosition(((float)i) * elevationScale, ((float)j) * elevationScale) * 0.5f
                                        - elevationNoise2.getPosition(((float)i) * elevationScale2, ((float)j) * elevationScale2);

                    Point position = new Point(i, j);
                    if (elevation < 0.12)
                    {
                        tileMap[i, j] = new WaterTile(position);
                    }
                    else if (elevation > 0.48)
                    {
                        tileMap[i, j] = new MountainTile(position);
                    }
                    else if (temperature < 0.07)
                    {
                        tileMap[i, j] = new TundraTile(position);
                    }
                    else if (temperature < 0.12)
                    {
                        tileMap[i, j] = new TaigaTile(position);
                    }
                    else if (temperature < 0.3)
                    {

                        tileMap[i, j] = new ForestTile(position);
                    }
                    else if (temperature < 0.4)
                    {

                        tileMap[i, j] = new PlainsTile(position);
                    }
                    else if (temperature < 0.5)
                    {

                        tileMap[i, j] = new BrushTile(position);
                    }
                    else
                    {
                        tileMap[i, j] = new DesertTile(position);
                    }
                    if (tileMap[i, j] is LandTile)
                    {
                        ((LandTile)tileMap[i, j]).setPopulation((int)(10000*(0.5d - Math.Abs(temperature - 0.3d)) * generationRandom.Next(1, 5) * generationRandom.Next(1, 4) * generationRandom.Next(1, 3)));
                    }
                }
            }
            //connect tiles
            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for(int j = 0; j<tileMap.GetLength(1); j++)
                {
                    int borderingTiles = 8;
                    if (i == 0 || i == tileMap.GetLength(0) - 1)
                    {
                        borderingTiles -= 3; 
                        if (j == 0 || j == tileMap.GetLength(1) - 1)
                        {
                            borderingTiles -= 2;
                        }
                    } else if (j == 0 || j == tileMap.GetLength(1)-1)
                    {
                        borderingTiles -= 3;
                    }
                    Tile[] tiles = new Tile[borderingTiles];
                    int tileOn = 0;
                    for(int x = -1; x<=1; x++)
                    {
                        for(int y = -1; y <= 1; y++)
                        {
                            if((x != 0 || y != 0) && x + i > 0 && x + i < tileMap.GetLength(0) && y + j > 0 && y + j < tileMap.GetLength(1))
                            {
                                tiles[tileOn] = tileMap[x+i,y+j];
                                tileOn++;
                            }
                        }
                    }
                    tileMap[i, j].setBorderingTiles(tiles);
                }
            }
            //make countries
            List<LandTile> landTiles = new List<LandTile>();
            for(int i = 0; i< tileMap.GetLength(0); i++)
            {
                for(int j = 0; j<tileMap.GetLength(1); j++)
                {
                    if (tileMap[i,j] is LandTile)
                    {
                        landTiles.Add((LandTile)tileMap[i,j]);
                    }
                }
            }
            int countryCount = landTiles.Count/100;
            List<Country> countryList = new List<Country>();
            List<LandTile> capitalList = new List<LandTile>();
            for (int i = 0;i< countryCount; i++)
            {
                countryList.Add(new Country(NameGenerator.getNewName()));
                LandTile newCapital = landTiles[generationRandom.Next(landTiles.Count)];
                countryList[i].SetCapital(newCapital);
                newCapital.setCountry(countryList[i]);
                capitalList.Add(newCapital);
                landTiles.Remove(newCapital);
            }
            for (int i = 0; i<landTiles.Count; i++)
            {
                int minDist = getPointDifference(landTiles[i].getPointPosition(), capitalList[0].getPointPosition());
                Country closestCountry = capitalList[0].getCountry();
                for(int j = 0; j<capitalList.Count; j++)
                {
                    int dist = getPointDifference(landTiles[i].getPointPosition(), capitalList[j].getPointPosition());
                    if (dist < minDist)
                    {
                        minDist = dist;
                        closestCountry = capitalList[j].getCountry();
                    }
                }
                landTiles[i].setCountry(closestCountry);
            }
        }
        private static int getPointDifference(Point a, Point b)
        {
            int xDiff = Math.Abs(a.X - b.X);
            int yDiff = Math.Abs(a.Y - b.Y);
            int hypotenuse = ((xDiff*xDiff + yDiff*yDiff));
            return hypotenuse;
        }
        public static Tile getTileAtPosition(Point position)
        {
            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for (int j = 0; j < tileMap.GetLength(1); j++)
                {
                    if (tileMap[i, j].containsPoint(position))
                    {
                        return tileMap[i, j];
                    }
                }
            }
            return null;
        }
        public static Tile getTile(int x, int y)
        {
            if (x < 0)
            {
                throw new ArgumentException("X cannot be less than 0");
            }
            if (y < 0)
            {
                throw new ArgumentException("Y cannot be less than 0");
            }
            if (x > tileMap.GetLength(0))
            {
                throw new ArgumentException("X cannot be more than the amount of tile rows");
            }
            if (y > tileMap.GetLength(1))
            {
                throw new ArgumentException("X cannot be more than the amount of tile rows");
            }
            return tileMap[x, y];
        }
        /// <summary>
        /// Renders the world
        /// </summary>
        /// <param name="spriteBatch">the SpriteBatch to render it in</param>

        public static void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, null);
        }
        public static void Draw(SpriteBatch spriteBatch, Tile selectedTile)
        {
            double itemWidth = ((double)Game1.instance.GetScreenWidth() / (double)tileMap.GetLength(0) * viewScale);
            double itemHeight = ((double)Game1.instance.GetScreenHeight() / (double)tileMap.GetLength(1) * viewScale);
            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for (int j = 0; j < tileMap.GetLength(1); j++)
                {
                    tileMap[i, j].setPosition(new Rectangle((int)Math.Floor(itemWidth * i + xOffset), (int)Math.Floor(itemHeight * j + yOffset), (int)Math.Ceiling(itemWidth), (int)Math.Ceiling(itemHeight)));
                    
                    tileMap[i, j].Draw(spriteBatch);
                    if (tileMap[i, j] == selectedTile ) {
                        spriteBatch.Draw( Assets.GetTexture2D("selected-tile-overlay"), tileMap[i,j].getPosition(), Color.White);
                    }
                }
            }
        }
    }
}
