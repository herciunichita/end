using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    public enum DrawMode { NoiseMap, ColourMap, Mesh};
    public DrawMode drawMode;
    public int mapWidth;
    public int mapHeight;
    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;
    public float noiseScale;
    public bool autoUpdate;

    public TerrainType[] regions;

    [Range(0,1)]
    public Vector2 offset;
    

    public void generateMap()
    {
        float[,] noiseMap = PerlinNoise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale); 
        Color[] colourmap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentHeight < regions[i].height) 
                    {
                        colourmap[y * mapWidth + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap) 
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode==DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourmap,mapWidth,mapHeight));
        }
        else if (drawMode==DrawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve), TextureGenerator.TextureFromColourMap(colourmap, mapWidth, mapHeight));
        }
    }
    void OnValidate()
    {
        if (mapWidth < 1) 
        {
            mapWidth = 1;
        }
        if (mapHeight < 1) 
        {
            mapHeight = 1;
        }
    }
}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color colour;
    
}