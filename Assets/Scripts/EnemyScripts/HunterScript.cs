using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterScript : MonoBehaviour {

    public Transform startLoc;
    public GameObject bullet, MuzzleFlash, Trigger;
    public float rof;
    float nextfire;
    bool startFire = false;

	// Use this for initialization
	void Start () {
        nextfire = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time > nextfire && startFire == true)
        {
            nextfire = Time.time + rof;
            if(transform.localScale.x > 0)
            {
                Instantiate(bullet, startLoc.position, Quaternion.Euler(new Vector3(180, 0, 90)));
                Instantiate(MuzzleFlash, startLoc.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                Instantiate(bullet, startLoc.position, Quaternion.Euler(new Vector3(0, 180, 90)));
                Instantiate(MuzzleFlash, startLoc.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            }
        }

       // transform.position += transform.right * -1 * 2 * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            startFire = true;
            if (coll.transform.position.x > this.transform.position.x && this.transform.localScale.x > 0)
                this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
            else
                if(coll.transform.position.x < this.transform.position.x && this.transform.localScale.x < 0)
                this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            if (coll.transform.position.x > this.transform.position.x && this.transform.localScale.x > 0)
                this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
            else
              if (coll.transform.position.x < this.transform.position.x && this.transform.localScale.x < 0)
                this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
        }
    }

  
}
