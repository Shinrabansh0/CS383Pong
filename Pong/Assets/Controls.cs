using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public KeyCode moveUp = KeyCode.W; //Set Keys for movement
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f; //Speed of paddle
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;


	// Use this for initialization
    // Function called on launch
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
        var vel = rb2d.velocity;
        //When moveUp is pressed, move direction at velocity speed
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        //When moveDown is pressed, move direction at velocity speed
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed; //Negative speed indicates move down
        }
        //Only move when key is pressed
        else
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;
        var pos = transform.position;
        //Don't allow paddle to exceed upper/lower bounds
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
	}
}
