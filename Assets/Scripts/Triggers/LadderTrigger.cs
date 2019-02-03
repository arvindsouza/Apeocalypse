using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour {

    private Walk player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Walk>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void  OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            player.ClimbPossible = true;
        }

    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
                if (Input.GetAxis("Vertical") < 0) { 
                    Debug.Log(player.RB.gravityScale);
                    player.ClimbPossible = true;
                player.RB.gravityScale = 0;
                player.anim.SetBool("staticLadder", true);
                player.isClimbing = true;
            }
            else
            {
                player.ClimbPossible = false;
            }

        }
    }

 
}
