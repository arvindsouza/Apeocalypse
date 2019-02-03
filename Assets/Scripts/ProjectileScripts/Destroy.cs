using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public float lifespan;
    public GameObject Splat;

	// Use this for initialization
	void Awake () {
        Destroy(gameObject, lifespan);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if ((this.tag == "EnemyProjectile" && coll.tag == "Player") || (this.tag == "PlayerProjectile" && coll.tag == "Enemy") || (coll.gameObject.layer == 8 && this.tag == "PlayerProjectile"))
        {
            if(Splat)
            Instantiate(Splat, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
  
    }
}
