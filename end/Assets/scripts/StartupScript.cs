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
            GUI.Box(new Rect(10, 10, Screen.width, Screen.height), "Congratulations, you have survived the end.");
            Time.timeScale = 0;
            //GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.white, 1.5f * Time.deltaTime);
        }
        else
        {
            GUI.Box(new Rect(10, 10, 60, 20), "" + ((int)timer).ToString());
        }
    }

}
