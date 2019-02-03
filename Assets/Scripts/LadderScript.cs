using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour {

    private Walk player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Walk>();
	}
	

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            player.ClimbPossible = true;
            Debug.Log("Enter");

        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            player.ClimbPossible = false;
        }
    }
}
