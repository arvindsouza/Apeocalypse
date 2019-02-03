using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    public float damage, lifeSpan;
    private ApeHealth PlayerHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	void Awake()
    {
        Destroy(gameObject, lifeSpan);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player" && this.tag != "PlayerProjectile")
        {
            Destroy(gameObject);
            PlayerHealth = FindObjectOfType<ApeHealth>();
            PlayerHealth.AddDamage(damage);
        }
    }
}
