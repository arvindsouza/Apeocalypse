using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BomberScript : MonoBehaviour {

    public Transform BombSpawnLoc;
    public GameObject Bomb;
    public GameObject[] jetpack;
    public float rof, distance;
    float nextFire;
    bool startFire;
    public bool isFlying;
    Animator anim;
    Rigidbody2D RB;
    SpriteRenderer SR;
    int dir = 1;
    Vector3 initPos;

	// Use this for initialization
	void Start () {
        nextFire = 0;
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        initPos = transform.position;

        if (isFlying)
        {
            RB.gravityScale = 0;
            anim.SetBool("Ground", false);
            anim.SetBool("Flying", true);
            for (int i = 0; i < jetpack.Length; i++)
                jetpack[i].SetActive(true);
        }
        else
        {
            anim.SetBool("Ground", true);
            anim.SetBool("Flying", false);
            for (int i = 0; i < jetpack.Length; i++)
                jetpack[i].SetActive(false);
        }


        Vector3 invert = transform.localScale;
        invert.x = -invert.x;
        transform.localScale = invert;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.time > nextFire && startFire == true)
        {
            nextFire = Time.time + rof;
            Instantiate(Bomb, BombSpawnLoc.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }

        //Bomber Script
        transform.position += transform.right * 2 * Time.deltaTime * dir;
        if((Math.Abs(transform.position.x) >= (distance + Math.Abs(initPos.x))) || (Math.Abs(transform.position.x) <= (-distance + Math.Abs(initPos.x))))
        {
            Vector3 newscale = transform.localScale;
            newscale.x = newscale.x * -1;
            transform.localScale = newscale;
            dir *= -1;
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            startFire = true;
        }

      //  Debug.Log(coll.tag + "Fire" + startFire);
    }
}
