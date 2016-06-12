using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor (typeof( MapGenerator))]
public class MapGeneratorEditor : Editor {

    public override void OnInspectorGUI()
    {
        MapGenerator mapgen = (MapGenerator)target;
        DrawDefaultInspector();

        if (GUILayout.Button("Generate!"))
        {
            mapgen.generateMap();
        }
    }
    public void Start()
    {
        MapGenerator mapgen = (MapGenerator)target;
        mapgen.generateMap();
    }
}
