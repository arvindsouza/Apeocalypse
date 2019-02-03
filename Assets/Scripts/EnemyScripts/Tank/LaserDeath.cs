using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDeath : MonoBehaviour {

    public float lifespan;

    // Use this for initialization
    void Awake()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
