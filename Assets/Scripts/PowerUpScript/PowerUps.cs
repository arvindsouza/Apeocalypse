using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    public bool poweredUp;
    public float powerUpTime;
    float canPick;
    Animator anim;
    GunScript gun;

    public Sprite[] weapons;

 
	// Use this for initialization
	void Start () {
        poweredUp = false;
        canPick = 0;
        anim = GetComponent<Animator>();
        gun = FindObjectOfType<GunScript>();
    }

    // Update is called once per frame
 /*   void Update () {
        if (canPick + powerUpTime < Time.time)
        {
            poweredUp = false;
            Debug.Log(poweredUp);
            anim.SetBool("PoweredUpA", false);
            gun.gunArm.GetComponent<SpriteRenderer>().sprite = weapons[0];
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "PowerUpA")
        {
           // PowerUpA = true;
           // anim.SetBool("PowerUpA", true);
            poweredUp = true;
            canPick = Time.time;
            Destroy(coll.gameObject);
            anim.SetBool("PoweredUpA", true);
            gun.gunArm.GetComponent<SpriteRenderer>().sprite = weapons[1];
        }


    }*/
}
