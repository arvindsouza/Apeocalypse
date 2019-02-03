using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoss : MonoBehaviour {

    public GameObject boss, door, levelManager;
    Walk player;
    Vector3 initPos, initdoor;
    bool move = false, doorclose = true;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Walk>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!player.canWalk)
        {
            if (door.transform.position.y <= initdoor.y + 10 && doorclose)
                door.transform.position += transform.up * 6 * Time.deltaTime;
            else
                doorclose = false;
            if (move)
            {
                if (player.transform.position.x < initPos.x + 20)
                {
                    player.transform.position += transform.right * player.speed * Time.deltaTime;
                    player.anim.SetBool("walking", true);
                }
                else
                    player.canWalk = true;
            }

        }

	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            levelManager.GetComponent<AudioSource>().Pause();
            player.canWalk = false;
            initPos = coll.transform.position;
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
         initdoor = door.transform.position;
        if(doorclose)
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.5f);
        move = true;
        yield return new WaitForSeconds(2);
        boss.SetActive(true);
        boss.GetComponent<Rigidbody2D>().isKinematic = false;
        Destroy(this.gameObject);
    }
}
