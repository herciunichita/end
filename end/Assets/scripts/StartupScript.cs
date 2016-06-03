using UnityEngine;
using System.Collections;

public class StartupScript : MonoBehaviour {
    public float timer;
    private float internaltimer;
    void Awake()
    {
        //MapDisplay display = FindObjectOfType<MapDisplay>();
        MapGenerator mapgen = FindObjectOfType<MapGenerator>();
        mapgen.generateMap();
        internaltimer = timer;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
        }

    }

    void OnGUI()
    {
        
        if (timer == 0)
        {
            GUI.Box(new Rect(10, 10, 300, 30), "Congratulations, you have survived the end.");
        }
        else
        {
            GUI.Box(new Rect(10, 10, 60, 20), "" + ((int)timer).ToString());
        }
    }

}
