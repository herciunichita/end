using UnityEngine;
using System.Collections;

public class BasicFollowerAI : MonoBehaviour {
    public Transform target;
    public Transform follower;
    public float speed = 7;
    public float hover = 0.7f;
    public int chanceToTeleport = 1000;
    private float actualspeed;
    private bool lost;

	// Use this for initialization
	void Start () {
        lost = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(follower.position, target.position) > 100 )
        {
            actualspeed = 80f;
            transform.LookAt(target);
            transform.Translate(Vector3.forward * actualspeed * Time.deltaTime);
            transform.Translate(Vector3.up * hover * Time.deltaTime);
        }
        else if (Vector3.Distance(follower.position, target.position) > 30)
        {
            System.Random prng = new System.Random();
            actualspeed = speed;
            transform.LookAt(target);
            int decision = prng.Next(1, chanceToTeleport);
            if (decision >= chanceToTeleport - 1)
            {
                actualspeed = 0f;
                if ((int)prng.Next(1, 500) % 2 == 0)
                {
                    transform.Translate(Vector3.left * 2500f * Time.deltaTime);
                    transform.Translate(Vector3.forward * 2000f * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.right * 2500f * 2 * Time.deltaTime);
                    transform.Translate(Vector3.forward * 2000f * Time.deltaTime);
                }

            }
            transform.Translate(Vector3.forward * actualspeed * Time.deltaTime);
            transform.Translate(Vector3.up * hover * Time.deltaTime);
        }
        else
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * actualspeed * Time.deltaTime);
            transform.Translate(Vector3.up * hover * Time.deltaTime);
        }
        if (Vector3.Distance(follower.position, target.position) < 5)
        {
            lost = true;
        }
    }
    void OnGUI()
    {
        if (lost)
        {
            GUI.Box(new Rect(10, 10, Screen.width, Screen.height), "You finally came to an END.");
            Time.timeScale = 0;
        }
    }
}
