/*
 * Controls player movements
 * player aiming and shooting
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed;
    public float jumpForce;
    public float fireSpeed;
    public LayerMask groundLayer;
    public Joystick leftJoystick, rightJoystick;
    public GameObject bullet;

    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerCollider;
    private bool isGrounded = false;
    private bool isAiming;
    private Vector2 zero, lastPosition, curPosition;
    
	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        rightJoystick.DeadZone = 0.5f;
        zero = new Vector2(0, 0);
    }
    
    // Update is called once per frame
    void Update () {
        isGrounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer);
        curPosition = rightJoystick.Direction.normalized;
        if(!lastPosition.Equals(zero) && curPosition.Equals(zero)) {
            GameObject firedBullet = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            //Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            firedBullet.GetComponent<Rigidbody2D>().velocity = lastPosition.normalized * fireSpeed;
        }
        lastPosition = curPosition;
    }

    private void FixedUpdate() {
        if (isGrounded)
            playerRigidbody.velocity = new Vector2(leftJoystick.Horizontal * playerSpeed, leftJoystick.Vertical * jumpForce);
        else
            playerRigidbody.velocity = new Vector2(leftJoystick.Horizontal * playerSpeed, playerRigidbody.velocity.y);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }
}
