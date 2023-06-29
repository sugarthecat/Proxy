using GameProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public static void move(int x, int y)
        {
            xOffset += x;
            yOffset += y;
            if (yOffset < 0)
            {
                yOffset = 0;
            }
        }
        public static void generateWorld()
        {
            Noise temperatureNoise = new Noise();
            float tempscale = 0.04f;
            Noise elevationNoise = new Noise();
            Noise elevationNoise2 = new Noise();
            float elevationScale = 0.1f;
            float elevationScale2 = 0.04f;
            Random generationRandom = new Random();
            tileMap = new Tile[100, 100];
            for(int i = 0; i < tileMap.GetLength(0); i++) { 
                for(int j = 0; j < tileMap.GetLength(1); j++)
                {
                    int worldHeight = tileMap.GetLength(1);
                    double density = 0;
                    double latitudeTemp = (double)(worldHeight / 2 - Math.Abs(j- worldHeight / 2));
                    latitudeTemp /= (double)worldHeight;
                    double noiseTemp = temperatureNoise.getPosition(((float)i) * tempscale, ((float)j) * tempscale);

                    double temperature = latitudeTemp + noiseTemp/2;
                    double elevation = elevationNoise.getPosition(((float)i) * elevationScale, ((float)j) * elevationScale)
                                        - elevationNoise2.getPosition(((float)i) * elevationScale2, ((float)j) * elevationScale2)*0.7f;
                    if (temperature < 0.07)
                    {
                        tileMap[i, j] = new Tile(Assets.GetTexture2D("tundra"));
                    }
                    else if (elevation + temperature < 0.30 && elevation < 0.2 )
                    {
                        tileMap[i, j] = new Tile(Assets.GetTexture2D("water"));
                    }else if(elevation > 0.48)
                    {
                        tileMap[i, j] = new Tile(Assets.GetTexture2D("mountains"));
                    }
                    else if(temperature < 0.12)
                    {
                        tileMap[i, j] = new Tile(Assets.GetTexture2D("taiga"));
                    }
                    else if (temperature < 0.3)
                    {

                        tileMap[i, j] = new Tile(Assets.GetTexture2D("forest"));
                    }
                    else if (temperature < 0.4)
                    {

                        tileMap[i, j] = new Tile(Assets.GetTexture2D("plains"));
                    }
                    else if (temperature < 0.5)
                    {

                        tileMap[i, j] = new Tile(Assets.GetTexture2D("brushland"));
                    }
                    else
                    {
                        tileMap[i, j] = new Tile(Assets.GetTexture2D("desert"));

                    }
                }
            }
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
            return tileMap[x,y];
        }

        public static void draw(SpriteBatch spriteBatch)
        {
            int itemWidth = Game1.instance.getScreenWidth()/tileMap.GetLength(0);
            int itemHeight = Game1.instance.getScreenHeight()/tileMap.GetLength(1);
            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for(int j = 0; j < tileMap.GetLength(1); j++) {
                    tileMap[i, j].setPosition(new Rectangle(itemWidth * i + xOffset, itemHeight * j + yOffset, itemWidth, itemHeight));
                    tileMap[i, j].draw(spriteBatch);
                }
            }
        }
    }
}
