


using System.Collections.Generic;
using UnityEngine;

namespace FKUnitySnippets.Randomization
{
    public class PerlinNoiseMap
    {
        public float[,] Map { get; private set; }

        public PerlinNoiseMap(int width, int height, float scale = 1.0f, float offsetX = 0.0f, float offsetY = 0.0f)
        {
            Map = GeneratePerlinMap(width, height, scale, offsetX, offsetY);
        }

        public static float[,] GeneratePerlinMap(int width, int height, float scale = 1.0f, float offsetX = 0.0f, float offsetY = 0.0f)
        {
            if (scale <= 0)
            {
                scale = 0.0001f;
            }

            float[,] map = new float[width, height];

            for (int x = 0; x < width; x++)
            {
                var row = new List<string>();

                for (int y = 0; y < height; y++)
                {
                    float sampleX = (x + offsetX) / scale;
                    float sampleY = (y + offsetY) / scale;
                    map[x, y] = Mathf.PerlinNoise(sampleX, sampleY);

                    row.Add(map[x, y].ToString());
                }

                Debug.Log(string.Join(" ", row));
            }

            return map;
        }
    }
}