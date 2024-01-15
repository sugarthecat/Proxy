using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Proxy.FlagElements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Flag
    {
        private Color baseColor;
        private List<FlagElement> flagElements;
        public Flag(Country country)
        {
            flagElements = new List<FlagElement>();

            Random random = new Random();
            baseColor = Color.White;
            int darkValue = random.Next(60, 100);
            int darkSaturaion = random.Next(80,100);
            int hue1 = random.Next(0, 360);
            int hue2 = (hue1 + random.Next(30, 330))%360;
            List<Color> colors = new List<Color>();
            if(random.Next(10) == 0)
            {
                hue2 = hue1;
            }
            colors.Add(GetColorFromHSV(hue1, darkSaturaion, darkValue));
            colors.Add(baseColor);
            if (random.Next(10) == 0)
            {
                darkValue = random.Next(0, 40);
            }
            colors.Add(GetColorFromHSV(hue2, darkSaturaion, darkValue));
            if(random.Next(5) == 0)
            {
                colors.RemoveAt(random.Next(colors.Count));
            }
            if(random.Next(2) == 0)
            {
                //vertical stripes
                for(int i = 0; i< colors.Count; i++)
                {
                    flagElements.Add(new FlagRectangle(colors[i],new Rectangle(12 / colors.Count*i, 0,12/colors.Count,12)));
                }
            }
            else
            {
                //horizontal stripes

                for (int i = 0; i < colors.Count; i++)
                {
                    flagElements.Add(new FlagRectangle(colors[i], new Rectangle(0,12 / colors.Count * i, 12, 12 / colors.Count)));
                }
            }

        }
        public FlagElement GetElement(int index)
        {
            return flagElements[index];
        }
        public int GetElementCount()
        {
            return flagElements.Count;
        }
        public Color GetBaseColor()
        {
            return baseColor;
        }
        private Color GetRandomBadColor(Random random)
        {
            return new Color(random.Next(0,255), random.Next(0,255),random.Next(0,255));
        }
        private Color GetLightColor(Random random)
        {
            return GetColorFromHSV(random.Next(0, 360),0 , 100);
        }
        private Color GetDarkColor(Random random)
        {
            return GetColorFromHSV(random.Next(0, 360), random.Next(80, 100), random.Next(80,100));
        }
        private Color GetColorFromHSV(int hue, int saturation, int value)
        {
            float sat = saturation / 100f;
            float val = value / 100f;
            float colorWeight = sat * val;
            float modifier = val - colorWeight;
            float secondaryColorWeight = colorWeight * (1 - Math.Abs((hue / 60 % 2) - 1));
            float red = 0;
            float green = 0;
            float blue = 0;
            if (hue < 60)
            {
                red = colorWeight;
                green = secondaryColorWeight;
            }
            else if (hue < 120)
            {
                green = colorWeight;
                red = secondaryColorWeight;
            }
            else if (hue < 180)
            {
                green = colorWeight;
                blue = secondaryColorWeight;
            }
            else if (hue < 240)
            {
                blue = colorWeight;
                green = secondaryColorWeight;
            }
            else if (hue < 300)
            {
                blue = colorWeight;
                red = secondaryColorWeight;
            }
            else
            {
                red = colorWeight;
                blue = secondaryColorWeight;
            }
            red += modifier;
            blue += modifier;
            green += modifier;
            red *= 255;
            blue *= 255;
            green *= 255;
            //Debug.WriteLine("RGB: " + red + "," + green + "," + blue);
            return new Color((int)red, (int)green, (int)blue);
        }
    }
}
