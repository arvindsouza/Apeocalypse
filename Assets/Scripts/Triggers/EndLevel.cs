using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    CamScript cam;

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<CamScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        cam.canMove = false;
    }
}
