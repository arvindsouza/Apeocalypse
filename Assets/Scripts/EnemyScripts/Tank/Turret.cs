using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform startLoc;
    public GameObject bullet, MuzzleFlash, target, turret, turretSprite, tank;
    public float rof, angle;
    float nextfire;
    bool startFire = true;
    

    // Use this for initialization
    void Start()
    {
        nextfire = 0;
    }

    void Update()
    {
        if (target)
        {
            var dir = target.transform.position - (Vector3)turret.GetComponent<Rigidbody2D>().position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        }

        if(tank.transform.localScale.x > 0)
        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.Euler(0,0,
(angle)), 2 * Time.deltaTime);
        else
            turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.Euler(0, 0,
    (angle + 180)), 2 * Time.deltaTime);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > nextfire )
        {
            nextfire = Time.time + rof;
            Instantiate(bullet, startLoc.position, Quaternion.Euler(new Vector3(0, 0, angle - 90)));
            Instantiate(bullet, startLoc.position, Quaternion.Euler(new Vector3(0, 0, angle - 70)));
            Instantiate(bullet, startLoc.position, Quaternion.Euler(new Vector3(0, 0, angle - 110)));

            var muzzle =  Instantiate(MuzzleFlash, startLoc.position, Quaternion.Euler(0, 0, angle+180));
        }

        // transform.position += transform.right * -1 * 2 * Time.deltaTime;
    }

  /*  void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            startFire = true;


        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag == "PLayer")
        {
        //    turret.rotation = Quaternion.Slerp(turret.rotation, Quaternion.Euler(0,
        // 0, Quaternion.LookRotation(target.position - turret.position).z), 2 * Time.deltaTime);
        }
    }*/

}
