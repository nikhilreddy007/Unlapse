/*
 * Detects player approaching
 * Shoots player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    public float fireRate, fireSpeed;
    public LayerMask playerLayer;
    public GameObject bullet;
    private GameObject firedBullet;
    private bool playerDetected;
    private Vector3 fireDirection;
    private GameObject player;

    IEnumerator ShootTarget()
    {
        yield return new WaitForSeconds(fireRate);
        if (playerDetected) {
            fireDirection = player.transform.position - transform.position;
            firedBullet = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            //Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            firedBullet.GetComponent<Rigidbody2D>().velocity = fireDirection.normalized * fireSpeed;
        }
        StartCoroutine(ShootTarget());
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(ShootTarget());
    }
    void Update()
    {
        playerDetected = Physics2D.OverlapCircle(transform.position, 15, playerLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
