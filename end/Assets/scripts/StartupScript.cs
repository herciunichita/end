using UnityEngine;
using System.Collections;

public class StartupScript : MonoBehaviour {
    
    void Awake()
    {
        //MapDisplay display = FindObjectOfType<MapDisplay>();
        MapGenerator mapgen = FindObjectOfType<MapGenerator>();
        mapgen.generateMap();
    }

}
