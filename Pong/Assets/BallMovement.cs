using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    private Rigidbody2D rb2d;

    //Choose random direction for ball to move
    void BallStart()
    {
        float rand = Random.Range(0, 2);
        if(rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    //Resets ball after point is scored
    void BallReset()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    //Button to restart game
    void Restart()
    {
        BallReset();
        Invoke("BallStart", 2); //Time Delay before start (in seconds)
    }

    //Adjust ball speed after collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }


    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("BallStart", 2); //Time Delay before start (in seconds)

	}
}
