using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "ground")
        {
            Walk player = FindObjectOfType<Walk>();
            player.isClimbing = false;
            player.grounded = true;
            player.RB.gravityScale = 5;
            Debug.Log("Touched");
        }
    }
}
