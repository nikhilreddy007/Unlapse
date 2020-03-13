/*
 * Spawns new platforms
 * Spawns new enemies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] platform;
    public GameObject enemy;
    public Transform generationPoint;
    public float distanceBetween;

    private Vector3 platformDimens;

	// Use this for initialization
	void Start () {
        platformDimens = platform[0].GetComponent<BoxCollider2D>().transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x) {
            transform.position = new Vector3(transform.position.x + platformDimens.x + distanceBetween, transform.position.y, transform.position.z);
            Instantiate(platform[Random.Range(0, platform.Length)], transform.position, transform.rotation);
            Vector3 offset = new Vector3(Random.Range(-platformDimens.x / 2, platformDimens.x / 2), platformDimens.y, 0);
            Instantiate(enemy, transform.position + offset, transform.rotation);
        }
	}
}
