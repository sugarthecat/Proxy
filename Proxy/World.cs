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
        private static Tile[,] tileMap;
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

                    if (elevation < 0.12)
                    {
                        tileMap[i, j] = new WaterTile();
                    }
                    else if (elevation > 0.48)
                    {
                        tileMap[i, j] = new MountainTile();
                    }
                    else if (temperature < 0.07)
                    {
                        tileMap[i, j] = new TundraTile();
                    }
                    else if (temperature < 0.12)
                    {
                        tileMap[i, j] = new TaigaTile();
                    }
                    else if (temperature < 0.3)
                    {

                        tileMap[i, j] = new ForestTile();
                    }
                    else if (temperature < 0.4)
                    {

                        tileMap[i, j] = new PlainsTile();
                    }
                    else if (temperature < 0.5)
                    {

                        tileMap[i, j] = new BrushTile();
                    }
                    else
                    {
                        tileMap[i, j] = new DesertTile();

                    }
                }
            }
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
        public static void draw(SpriteBatch spriteBatch)
        {
            double itemWidth = ((double)Game1.instance.GetScreenWidth() / (double)tileMap.GetLength(0) * viewScale);
            double itemHeight = ((double)Game1.instance.GetScreenHeight() / (double)tileMap.GetLength(1) * viewScale);
            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for (int j = 0; j < tileMap.GetLength(1); j++)
                {
                    tileMap[i, j].setPosition(new Rectangle((int)Math.Floor(itemWidth * i + xOffset), (int)Math.Floor(itemHeight * j + yOffset), (int)Math.Ceiling(itemWidth), (int)Math.Ceiling(itemHeight)));
                    tileMap[i, j].draw(spriteBatch);
                }
            }
        }
    }
}
