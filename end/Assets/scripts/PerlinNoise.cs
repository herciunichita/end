/*using UnityEngine;
using System.Collections;

public static class PerlinNoise {

    public static float[,] GenerateNoiseMap (int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset){

        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        float[,] noiseMap = new float[mapWidth,mapHeight];

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;


                for (int a = 0; a < octaves; a++)
                {
                    float x = (i - halfWidth) / scale * frequency + octaveOffsets[a].x;
                    float y = (j - halfHeight) / scale * frequency + octaveOffsets[a].y;

                    float perlinValue = Mathf.PerlinNoise(x, y) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight) 
                {
                    minNoiseHeight = noiseHeight;
                }
               
                noiseMap[i, j] = noiseHeight;

            }
        }

        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                noiseMap[i, j] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[i, j]);
            }
        }
                return noiseMap;

    }
	
}
*/

using UnityEngine;
using System.Collections;

public static class PerlinNoise
{

    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale)
    {
        System.Random prng = new System.Random();
        float xx1 = prng.Next(-1000, 1000);
        float yy1 = prng.Next(-1000, 1000);
        float xx2 = prng.Next(-100, 100);
        float yy2 = prng.Next(-100, 100);

        float[,] noiseMap = new float[mapWidth, mapHeight];

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                //xx2 = prng.Next(-100, 100);
                //yy2 = prng.Next(-100, 100);
                float sampleX = x / scale + xx1 + xx2 ;
                float sampleY = y / scale + yy1 + yy2 ;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue;
            }
        }

        return noiseMap;
    }

}