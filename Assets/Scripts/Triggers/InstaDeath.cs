using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaDeath : MonoBehaviour {

    ApeHealth player;
    EnemyHealth enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            player = FindObjectOfType<ApeHealth>();
            player.AddDamage(player.MaxHealth);
        }
        else if(coll.tag == "Enemy")
        {
            enemy = FindObjectOfType<EnemyHealth>();
            enemy.addDamage(enemy.maxhealth);
        }
    }
}
