/*
 * Destroys any object that goes out of frame
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    private GameObject camera;
    private float platformWidth;

    // Use this for initialization
    void Start () {
        camera = GameObject.FindWithTag("MainCamera");
        platformWidth = GameObject.FindWithTag("Platform").transform.localScale.x;
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < camera.transform.position.x - platformWidth*2)
        {
            Destroy(gameObject);
        }
	}
}
