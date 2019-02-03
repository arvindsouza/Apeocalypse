using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    ApeHealth health;
    Health healthSprites;
    public float healthamt;
    Walk ape;

	// Use this for initialization
	void Start () {
        health = FindObjectOfType<ApeHealth>();
        healthSprites = FindObjectOfType<Health>();
        ape = FindObjectOfType<Walk>();
            }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            ape.didpick = true;
            health.addHealth(healthamt);
            healthSprites.updateHearts();
            Destroy(gameObject);
        }
    }

}
