using UnityEngine;
using System.Collections;

public static class PerlinNoise
{

    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale)
    {
        System.Random prng = new System.Random();
        float mainRandomX = prng.Next(-1000, 1000);
        float mainRandomY = prng.Next(-1000, 1000);


        float[,] noiseMap = new float[mapWidth, mapHeight];

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float detailRandomX = prng.Next(-1, 1);
                float detailRandomY = prng.Next(-1, 1);
                float sampleX = x / scale + mainRandomX + detailRandomX/scale ;
                float sampleY = y / scale + mainRandomY + detailRandomY/scale ;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue;
            }
        }

        return noiseMap;
    }

}