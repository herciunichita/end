using UnityEngine;
using System.Collections;

public class BasicFollowerAI : MonoBehaviour {
    public Transform target;
    public Transform follower;
    public float speed = 10;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
