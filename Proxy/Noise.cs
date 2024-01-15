﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Proxy
{
    internal class Noise
    {
        private Random generationRandom = new Random();
        private Dictionary<Vector2, Vector2> positionDict;

        public Noise()
        {
            generationRandom = new Random();
            positionDict = new Dictionary<Vector2, Vector2>();
        }

        private float interpolate(float a0, float a1, float w)
        {
            return (a1 - a0) * w + a0;
        }

        private Vector2 randomGradient(int x, int y)
        {
            Vector2 positionVector = new Vector2(x, y);
            if (!positionDict.ContainsKey(positionVector))
            {
                double randValue = (generationRandom.NextDouble() * Math.PI * 2);
                positionDict.Add(positionVector, new Vector2((float)Math.Sin(randValue), (float)Math.Cos(randValue)));
            }
            return positionDict[positionVector];
        }

        private float dotGridGradient(int ix, int iy, float x, float y)
        {
            Vector2 gradient = randomGradient(ix, iy);

            float dx = x - (float)ix;
            float dy = y - (float)iy;

            return (dx * gradient.X + dy * gradient.Y);
        }

        public float getPosition(float x, float y)
        {
            int x0 = (int)Math.Floor(x);
            int x1 = x0 + 1;
            int y0 = (int)Math.Floor(y);
            int y1 = y0 + 1;
            float sx = x - (float)x0;
            float sy = y - (float)y0;

            float n0, n1, ix0, ix1, value;

            n0 = dotGridGradient(x0, y0, x, y);
            n1 = dotGridGradient(x1, y0, x, y);
            ix0 = interpolate(n0, n1, sx);
            n0 = dotGridGradient(x0, y1, x, y);
            n1 = dotGridGradient(x1, y1, x, y);
            ix1 = interpolate(n0, n1, sx);

            value = interpolate(ix0, ix1, sy);
            return value;
        }
    }
}