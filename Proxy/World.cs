using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Proxy.Tile_Types;
using System;
using System.Collections.Generic;

namespace Proxy
{
    internal static class World
    {
        private static List<Country> countries;
        private static int currentTime = 0;
        private static string mapMode = "geography";
        private static Tile[,] tileMap;
        private static double viewScale = 1;
        private static int xOffset = 0;
        private static int yOffset = 0;

        public static void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, null);
        }

        /// <summary>
        /// Renders the world
        /// </summary>
        /// <param name="spriteBatch">the SpriteBatch to render it in</param>
        public static void Draw(SpriteBatch spriteBatch, Tile selectedTile)
        {
            double itemWidth = ((double)Game1.GetScreenWidth() / (double)tileMap.GetLength(0) * viewScale);
            double itemHeight = ((double)Game1.GetScreenHeight() / (double)tileMap.GetLength(1) * viewScale);
            double itemSize;
            if (itemWidth > itemHeight)
            {
                itemSize = itemWidth;
            }
            else
            {
                itemSize = itemHeight;
            }
            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for (int j = 0; j < tileMap.GetLength(1); j++)
                {
                    tileMap[i, j].setPosition(new Rectangle((int)Math.Floor(itemSize * i + xOffset), (int)Math.Floor(itemSize * j + yOffset), (int)Math.Ceiling(itemSize), (int)Math.Ceiling(itemSize)));

                    tileMap[i, j].Draw(spriteBatch);
                    if (tileMap[i, j] == selectedTile)
                    {
                        spriteBatch.Draw(Assets.GetTexture2D("selected-tile-overlay"), tileMap[i, j].getPosition(), Color.White);
                    }
                }
            }
        }

        public static void GenerateWorld()
        {
            Noise temperatureNoise = new();
            float tempscale = 0.03f;
            Noise elevationNoise = new();
            Noise elevationNoise2 = new();
            float elevationScale = 0.08f;
            float elevationScale2 = 0.02f;
            Random generationRandom = new();
            tileMap = new Tile[300, 100];
            //generate terrain
            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for (int j = 0; j < tileMap.GetLength(1); j++)
                {
                    int worldHeight = tileMap.GetLength(1);
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
                        ((LandTile)tileMap[i, j]).setPopulation((int)(10000 *
                                (0.5d - Math.Abs(temperature - 0.3d))
                                * (1 - elevation)
                                * generationRandom.Next(1, 3)
                                * generationRandom.Next(1, 3)
                                * generationRandom.Next(1, 3)
                                ));
                        ((LandTile)tileMap[i, j]).setResourceCount(new ResourceCount(elevation, temperature));
                    }
                }
            }
            //connect tiles
            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for (int j = 0; j < tileMap.GetLength(1); j++)
                {
                    int borderingTiles = 8;
                    if (i == 0 || i == tileMap.GetLength(0) - 1)
                    {
                        borderingTiles -= 3;
                        if (j == 0 || j == tileMap.GetLength(1) - 1)
                        {
                            borderingTiles -= 2;
                        }
                    }
                    else if (j == 0 || j == tileMap.GetLength(1) - 1)
                    {
                        borderingTiles -= 3;
                    }
                    Tile[] tiles = new Tile[borderingTiles];
                    int tileOn = 0;
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            if ((x != 0 || y != 0) && x + i > 0 && x + i < tileMap.GetLength(0) && y + j > 0 && y + j < tileMap.GetLength(1))
                            {
                                tiles[tileOn] = tileMap[x + i, y + j];
                                tileOn++;
                            }
                        }
                    }
                    tileMap[i, j].setBorderingTiles(tiles);
                }
            }
            //make countries
            List<LandTile> landTiles = new List<LandTile>();
            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for (int j = 0; j < tileMap.GetLength(1); j++)
                {
                    if (tileMap[i, j] is LandTile)
                    {
                        landTiles.Add((LandTile)tileMap[i, j]);
                    }
                }
            }
            int countryCount = landTiles.Count / 100;
            List<Country> countryList = new List<Country>();
            List<LandTile> capitalList = new List<LandTile>();
            for (int i = 0; i < countryCount; i++)
            {
                countryList.Add(new Country(NameGenerator.getNewName()));
                LandTile newCapital = landTiles[generationRandom.Next(landTiles.Count)];
                countryList[i].SetCapital(newCapital);
                newCapital.setCountry(countryList[i]);
                capitalList.Add(newCapital);
                landTiles.Remove(newCapital);
            }
            for (int i = 0; i < landTiles.Count; i++)
            {
                int minDist = GetPointDifference(landTiles[i].getPointPosition(), capitalList[0].getPointPosition());
                Country closestCountry = capitalList[0].getCountry();
                for (int j = 0; j < capitalList.Count; j++)
                {
                    int dist = GetPointDifference(landTiles[i].getPointPosition(), capitalList[j].getPointPosition());
                    if (dist < minDist)
                    {
                        minDist = dist;
                        closestCountry = capitalList[j].getCountry();
                    }
                }
                landTiles[i].setCountry(closestCountry);
            }
            countries = countryList;
        }

        public static string getCurrentTime()
        {
            int days = 1 + (currentTime % 30);
            int months = (((currentTime - days) / 30) % 12) + 1;
            int years = (currentTime - days - months * 30) / 360;
            return months + "/" + days + "/" + years;
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

        public static void Move(int x, int y)
        {
            xOffset += x;
            yOffset += y;
            int ylim = (int)(Game1.GetScreenHeight() * 1d - Game1.GetLargestScreenDimension() * viewScale);
            int xlim = (int)(Game1.GetScreenWidth() * 1d - Game1.GetLargestScreenDimension() * viewScale);
            int ymax = (int)(Game1.GetScreenHeight() * viewScale * 0.1d);
            int xmax = 0;
            if (xOffset < xlim)
            {
                xOffset = xlim;
            }
            if (yOffset < ylim)
            {
                yOffset = ylim;
            }
            if (xOffset > xmax) 
            {
                xOffset = xmax;
            }
            if (yOffset > ymax)
            {
                yOffset = ymax;
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
            double sizeDiff = (previousWidth - viewScale) / 2;
            Move((int)(sizeDiff * Game1.GetScreenWidth()), (int)(sizeDiff * Game1.GetScreenHeight()));
        }

        public static void DoWorldTick()
        {
            UpdateCountryStats();
            currentTime++;
        }

        private static void UpdateCountryStats()
        {
            for (int i = 0; i < countries.Count; i++)
            {
                countries[i].UpdateStats();
            }
        }

        private static int GetPointDifference(Point a, Point b)
        {
            int xDiff = Math.Abs(a.X - b.X);
            int yDiff = Math.Abs(a.Y - b.Y);
            int hypotenuse = ((xDiff * xDiff + yDiff * yDiff));
            return hypotenuse;
        }
    }
}