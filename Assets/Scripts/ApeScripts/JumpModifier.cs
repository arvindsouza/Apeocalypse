using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpModifier : MonoBehaviour {

    public float fallMultiplier = 2.5f;
    public float lowFallMultiplier = 2f;

    Rigidbody2D rb;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
 
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowFallMultiplier - 1) * Time.deltaTime;
        }
	}
}
