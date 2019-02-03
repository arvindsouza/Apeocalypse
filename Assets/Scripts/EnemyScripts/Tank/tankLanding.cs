using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankLanding : MonoBehaviour {

    public GameObject tank, player, levelManager;
    Animator anim;
    bool landed = false;

    // Use this for initialization
    void Start() {
        anim = tank.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            anim.SetTrigger("landed");
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        if (!landed)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15, 15), ForceMode2D.Impulse);
            tank.GetComponent<AudioSource>().Play();

        }
        landed = true;
        yield return new WaitForSeconds(1.3f);
        anim.SetBool("walk", true);
        levelManager.GetComponent<AudioSource>().UnPause();
    }
}
