using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour {

    public GameObject startLoc, laser, MuzzleFlash, laserObject, target, charge, tank;
    public float rof, angle;
    float nextfire;
    bool startFire = false, firing;
    GameObject cloneLaser;
    Quaternion currentRot;


    // Use this for initialization
    void Start()
    {
        nextfire = 0;
    }

    void Update()
    {
        if (target)
        {
            var dir = target.transform.position - (Vector3)laserObject.GetComponent<Rigidbody2D>().position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        }



        if (cloneLaser)
        {
            cloneLaser.transform.position = startLoc.transform.position;
            if (tank.transform.localScale.x > 0)
                cloneLaser.transform.localRotation = currentRot;
            else
                cloneLaser.transform.localRotation = currentRot * Quaternion.Euler(0, 0, 180);

        }

    }

    void LateUpdate()
    {
        if (startFire && !firing)
        {
            if(tank.transform.localScale.x > 0)
            laserObject.transform.rotation = Quaternion.Euler(0, 0, angle + 180);
            else
                laserObject.transform.rotation = Quaternion.Euler(0, 0, angle );
        }
        else if(firing)
        {
            laserObject.transform.rotation = currentRot;
        }

        if (charge.activeSelf == true)
        {
            firing = true;
        }
        else if(cloneLaser == null)
        {
            firing = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > nextfire && startFire)
        {
            charge.SetActive(true);
            nextfire = Time.time + rof;
            StartCoroutine(enableLaserB());
                currentRot = laserObject.transform.rotation;
            //    laserObject.transform.rotation = Quaternion.Slerp(laserObject.transform.rotation, Quaternion.Euler(0, 0,
            //(90)), 2 * Time.deltaTime);
            // var muzzle = Instantiate(MuzzleFlash, startLoc.transform.position, Quaternion.Euler(0, 0, angle + 180));
        }


        // transform.position += transform.right * -1 * 2 * Time.deltaTime;
    }

    public IEnumerator enableLaserB()
    {
        charge.SetActive(true);
        yield return new WaitForSeconds(.8f);
        if(tank.transform.localScale.x > 0)
        cloneLaser = Instantiate(laser, startLoc.transform.position,  currentRot);
        else
            cloneLaser = Instantiate(laser, startLoc.transform.position, currentRot * Quaternion.Euler(0, 0, 180));
        charge.SetActive(false);
    }

    public void enableLaser()
    {
        //charge.SetActive(true);
      //  yield return new WaitForSeconds(1);
        startLoc.SetActive(true);
        startFire = true;
        laserObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }
}
