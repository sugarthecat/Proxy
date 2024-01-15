using System;
using System.Collections.Generic;

namespace Proxy
{
    internal static class NameGenerator
    {
        private struct itemCommonalityPair
        {
            public string item;
            public int commonality;

            public itemCommonalityPair(string name, int commonality)
            {
                this.item = name;
                this.commonality = commonality;
            }
        };

        private static List<string> takenNames = new List<string>();
        private static Random random = new Random();

        private static string generateName()
        {
            itemCommonalityPair[] startConsonant = {
                new itemCommonalityPair("b", 5),
                new itemCommonalityPair("c", 1),
                new itemCommonalityPair("d", 5),
                new itemCommonalityPair("f", 3),
                new itemCommonalityPair("g", 2),
                new itemCommonalityPair("h", 1),
                new itemCommonalityPair("j", 1),
                new itemCommonalityPair("k", 1),
                new itemCommonalityPair("l", 2),
                new itemCommonalityPair("s", 2),
                new itemCommonalityPair("m", 3),
                new itemCommonalityPair("n", 3),
                new itemCommonalityPair("p", 1),
                new itemCommonalityPair("r", 5),
                new itemCommonalityPair("t", 4),
                new itemCommonalityPair("v", 1),
                new itemCommonalityPair("st", 2),
                new itemCommonalityPair("br", 2),
                new itemCommonalityPair("gr", 2),
                new itemCommonalityPair("sc", 1),
                new itemCommonalityPair("gh", 1),
                new itemCommonalityPair("cr", 1),
                new itemCommonalityPair("wr", 1),
                new itemCommonalityPair("fr", 1),
                new itemCommonalityPair("tr", 1),
                new itemCommonalityPair("ch", 1),
                new itemCommonalityPair("gl", 1),
            };
            itemCommonalityPair[] nonStartConsonant = {
                new itemCommonalityPair("b", 5),
                new itemCommonalityPair("c", 1),
                new itemCommonalityPair("d", 5),
                new itemCommonalityPair("f", 3),
                new itemCommonalityPair("g", 2),
                new itemCommonalityPair("h", 1),
                new itemCommonalityPair("j", 1),
                new itemCommonalityPair("k", 1),
                new itemCommonalityPair("l", 2),
                new itemCommonalityPair("s", 2),
                new itemCommonalityPair("m", 3),
                new itemCommonalityPair("n", 3),
                new itemCommonalityPair("p", 1),
                new itemCommonalityPair("r", 5),
                new itemCommonalityPair("t", 4),
                new itemCommonalityPair("v", 2),
                new itemCommonalityPair("st", 2),
                new itemCommonalityPair("gr", 2),
                new itemCommonalityPair("rl", 1),
                new itemCommonalityPair("sc", 1),
                new itemCommonalityPair("gh", 1),
                new itemCommonalityPair("lm", 1),
                new itemCommonalityPair("th", 1),
                new itemCommonalityPair("ch", 1),
            };
            itemCommonalityPair[] vowel = {
                new itemCommonalityPair("a", 20),
                new itemCommonalityPair("e", 30),
                new itemCommonalityPair("i", 10),
                new itemCommonalityPair("o", 15),
                new itemCommonalityPair("u", 5),
                new itemCommonalityPair("ea", 2),
                new itemCommonalityPair("ou", 1),
                new itemCommonalityPair("eo", 1),
                new itemCommonalityPair("ue", 1),
            };
            string name = getItemWeighted(startConsonant) + getItemWeighted(vowel) + getItemWeighted(nonStartConsonant) + getItemWeighted(vowel) + getItemWeighted(nonStartConsonant);

            name = name[0].ToString().ToUpper() + name.Substring(1);
            return name;
        }

        private static string getItemWeighted(itemCommonalityPair[] pairs)
        {
            int total = 0;
            for (int i = 0; i < pairs.Length; i++)
            {
                total += pairs[i].commonality;
            }
            int item = random.Next(0, total);
            total = 0;
            for (int i = 0; i < pairs.Length; i++)
            {
                if (item < total + pairs[i].commonality)
                {
                    return pairs[i].item;
                }
                total += pairs[i].commonality;
            }
            return pairs[0].item;
        }

        public static string getNewName(Tile tile)
        {
            string name = null;
            for (int i = 0; i < 100; i++)
            {
                name = generateName();
                if (!takenNames.Contains(name))
                {
                    takenNames.Add(name);
                    return name;
                }
            }
            return name;
        }

        public static string getNewName()
        {
            string name = null;
            for (int i = 0; i < 100; i++)
            {
                name = generateName();
                if (!takenNames.Contains(name))
                {
                    takenNames.Add(name);
                    return name;
                }
            }
            return name;
        }
    }
}