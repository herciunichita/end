using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor (typeof( MapGenerator))]
public class MapGeneratorEditor : Editor {

    public override void OnInspectorGUI()
    {
        MapGenerator mapgen = (MapGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mapgen.autoUpdate)
            {
                mapgen.generateMap();
            }
        }
        if (GUILayout.Button("Generate!"))
        {
            mapgen.generateMap();
        }
    }
}
