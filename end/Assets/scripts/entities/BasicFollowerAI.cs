﻿using UnityEngine;
using System.Collections;

public class BasicFollowerAI : MonoBehaviour {
    public Transform target;
    public Transform follower;
    public float speed = 7;
    public float hover = 0.7f;
    private float actualspeed;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(follower.position, target.position) > 50 )
        {
            actualspeed = 80f;
        }
        else
        {
            actualspeed = speed;
        }
        transform.LookAt(target);
        transform.Translate(Vector3.forward * actualspeed * Time.deltaTime);
        transform.Translate(Vector3.up * hover * Time.deltaTime);
	}
}
