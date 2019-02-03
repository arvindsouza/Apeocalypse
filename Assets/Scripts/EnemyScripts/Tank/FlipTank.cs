using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTank : MonoBehaviour {

    public GameObject tank;

void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "ground")
        {
            tank.transform.localScale = new Vector3( tank.transform.localScale.x * -1, 1, 1);
        }
    }
}
