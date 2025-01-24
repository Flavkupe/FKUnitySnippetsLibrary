using UnityEngine;

namespace FKUnitySnippets.Randomization
{
    public class PerlinNoiseMap
    {
        public float[,] Map { get; private set; }

        public PerlinNoiseMap(int width, int height, float scale = 1.0f, float offsetX = 0.0f, float offsetY = 0.0f, int seed = 0)
        {
            Map = GeneratePerlinMap(width, height, scale, offsetX, offsetY, seed);
        }

        public static float[,] GeneratePerlinMap(int width, int height, float scale = 1.0f, float offsetX = 0.0f, float offsetY = 0.0f, int seed = 0)
        {
            if (scale <= 0)
            {
                scale = 0.0001f;
            }

            var seedOffset = GenerateSeedOffset(seed);
            offsetX += seedOffset.x;
            offsetY += seedOffset.y;

            float[,] map = new float[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    float sampleX = (x + offsetX) / scale;
                    float sampleY = (y + offsetY) / scale;
                    map[x, y] = Mathf.PerlinNoise(sampleX, sampleY);
                }
            }

            return map;
        }


        private static Vector2 GenerateSeedOffset(int seed)
        {
            Random.InitState(seed);
            float offsetX = Random.Range(-10000f, 10000f);
            float offsetY = Random.Range(-10000f, 10000f);
            return new Vector2(offsetX, offsetY);
        }
    }
}