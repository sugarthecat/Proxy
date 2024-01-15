using System;

namespace Proxy
{
    public struct ResourceCount
    {
        public int oil;
        public int coal;
        public int food;
        public int rubber;
        public int gold;
        public int lumber;
        public int bauxite;
        public int lithium;
        public int titanium;
        public int uranium;

        public ResourceCount()
        {
            oil = 0;
            coal = 0;
            food = 0;
            rubber = 0;
            gold = 0;
            lumber = 0;
            bauxite = 0;
            lithium = 0;
            titanium = 0;
            uranium = 0;
        }

        public ResourceCount(double elevation, double temperature)
        {
            Random random = new Random();
            if (temperature > 0)
            {
                oil = random.Next((int)(Math.Pow((double)(temperature * 2), 20)));
            }
            else
            {
                oil = 0;
                if (random.Next(5) == 3)
                {
                    oil = random.Next(5);
                }
            }
            coal = random.Next((int)(elevation * 50 + 10), (int)(elevation * 100 + 20));
            food = random.Next(5);
            if (temperature > 0.40)
            {
                food += (int)((0.60d - temperature) * 500);
            }
            else
            {
                food += (int)((temperature / 2d) * 500);
            }
            if (food < 0)
            {
                food = 0;
            }
            rubber = random.Next(5);

            if (temperature > 0.35)
            {
                rubber += (int)((0.40d - temperature) * 2500);
            }
            else
            {
                rubber += (int)((temperature - 0.3d) * 2500);
            }
            if (rubber < 0)
            {
                rubber = random.Next(3);
            }
            gold = random.Next((int)(elevation * 100), (int)(elevation * 200));
            lumber = 0;
            if (temperature > 0.30)
            {
                lumber += (int)((0.60d - temperature) * 500);
            }
            else
            {
                lumber += (int)(temperature * 500);
            }
            if (lumber < 0)
            {
                lumber = random.Next(1);
            }
            if (lumber < 0)
            {
                lumber = 0;
            }
            lithium = (int)((temperature - 0.4d) * 500);
            if (lithium < 0)
            {
                lithium = random.Next(1);
            }
            titanium = random.Next(10);
            uranium = 1;
            bauxite = (int)(elevation * 5);
            for (int i = 0; i < 10; i++)
            {
                uranium += random.Next(1, 10);
                bauxite += random.Next(1, 10);
            }
            if (uranium > 70)
            {
                uranium = random.Next(100, 1000);
            }
            else
            {
                uranium = random.Next(1);
            }
            if (bauxite > 65)
            {
                bauxite = random.Next(200, 500);
            }
            else
            {
                bauxite = random.Next(2);
            }
        }

        public void addResource(ResourceCount resource)
        {
            oil += resource.oil;
            coal += resource.coal;
            food += resource.food;
            rubber += resource.rubber;
            gold += resource.gold;
            lumber += resource.lumber;
            bauxite += resource.bauxite;
            lithium += resource.titanium;
            titanium += resource.titanium;
            uranium += resource.uranium;
        }
    }
}