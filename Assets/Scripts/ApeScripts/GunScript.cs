using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public Vector3 playerPos;

    //Projectile
    public Transform startLoc;
    public GameObject banana, MuzzleFlash;
    public float rof, angle;
    protected float nextfire;
    public Vector3 mousePos;
    public Transform gunArm;
    GameObject cloneFlash;

    //PowerUps
    protected bool laserCreated = false;
    public float powerUpTime;
    public GameObject Laser, cloneLaser;

    Walk player;
    PowerUps power;

    public Transform playerTransform;

    //Arm Rotation
    float interceptA, interceptB, interceptC, lineA, lineB, lineC, lineE, mouseVal;
    Vector3 rangeTopDiagonal, rangeTopTop, rangeBot, rangeBotBot, rangeStart;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Walk>();
        power = FindObjectOfType<PowerUps>();
        playerTransform = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.canPick + powerUpTime < Time.time)
        {
            player.poweredUp = false;
            player.anim.SetBool("PoweredUpA", false);
            laserCreated = false;
            Destroy(cloneLaser);
        }


        if (Input.GetButtonUp("Fire1"))
        {
            player.anim.SetBool("fire", false);
            gunArm.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            if (player.poweredUp == true)
            {
                laserCreated = false;
                Destroy(cloneLaser);
            }
        }
        //Fire Projectile
        if (Input.GetButton("Fire1"))
        {
            fireProjectile();
        }

        //Change Gun
        if (!player.poweredUp)
        {
            gunArm.gameObject.GetComponent<SpriteRenderer>().sprite = player.weapons[0];
        }


        //ROTATE ARM
        mousePos = Camera.main.ScreenToWorldPoint((new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
        playerPos = player.transform.position;
        rangeStart = playerPos ;
        rangeTopTop = playerPos + new Vector3(-5, 14, 0);
        rangeBotBot = playerPos + new Vector3(5, -10, 0);
      //  interceptC = rangeTopTop.y - ((rangeTopTop.y - rangeStart.y) / (rangeTopTop.x - rangeStart.x)) * rangeTopTop.x;
  //      lineC = mousePos.y - ((rangeTopTop.y - rangeStart.y) / (rangeTopTop.x - rangeStart.x)) * mousePos.x - interceptC;


        if (player.transform.localScale.x > 0)
        {
            interceptA = rangeTopTop.y - ((rangeTopTop.y - rangeStart.y) / (rangeTopTop.x - rangeStart.x)) * rangeTopTop.x;
            interceptB = rangeBotBot.y - ((rangeBotBot.y - rangeStart.y) / (rangeBotBot.x - rangeStart.x)) * rangeBotBot.x;
            lineA = mousePos.y - ((rangeTopTop.y - rangeStart.y) / (rangeTopTop.x - rangeStart.x)) * mousePos.x - interceptA;
            lineB = mousePos.y - ((rangeBotBot.y - rangeStart.y) / (rangeBotBot.x - rangeStart.x)) * mousePos.x - interceptB;
            mouseVal = lineA * lineB;

                
                    var dir = mousePos - (Vector3)gunArm.transform.position;
                     angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    gunArm.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                
        }
        else
        {
            rangeTopTop = playerPos + new Vector3(5, 14, 0);
            rangeBotBot = playerPos + new Vector3(-5, -10, 0);
            interceptA = rangeTopTop.y - ((rangeTopTop.y - rangeStart.y) / (rangeTopTop.x - rangeStart.x)) * rangeTopTop.x;
            interceptB = rangeBotBot.y - ((rangeBotBot.y - rangeStart.y) / (rangeBotBot.x - rangeStart.x)) * rangeBotBot.x;
            lineA = mousePos.y - ((rangeTopTop.y - rangeStart.y) / (rangeTopTop.x - rangeStart.x)) * mousePos.x - interceptA;
            lineB = mousePos.y - ((rangeBotBot.y - rangeStart.y) / (rangeBotBot.x - rangeStart.x)) * mousePos.x - interceptB;
            mouseVal = lineA * lineB;
          

                var dir = mousePos - (Vector3)gunArm.transform.position;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                gunArm.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));


        }

        if (cloneFlash)
        {
            cloneFlash.transform.position = startLoc.position;
            cloneFlash.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
        }
    }

    protected void fireProjectile()
    {
        // Laser Power Up
        if (player.poweredUp == true)
        {
            if (laserCreated == false)
            {
                laserCreated = true;
                cloneLaser = Instantiate(Laser, (startLoc.position), Quaternion.Euler(new Vector3(0, 0, angle  )));
            }
            
            if (cloneLaser)
            {
                cloneLaser.transform.position = startLoc.position;
                cloneLaser.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
      

        }
        else
        {
            player.anim.SetBool("fire", true);
            if (Time.time > nextfire)
            {
                nextfire = Time.time + rof;
                if(gunArm.rotation.z == 0 && player.facingRight)
                    Instantiate(banana, (startLoc.position), Quaternion.Euler(new Vector3(0, 0, 0)));
                else if(gunArm.rotation.z == 0 && !player.facingRight)
                    Instantiate(banana, (startLoc.position), Quaternion.Euler(new Vector3(180, 0, 180)));
                else
                {
                    if (player.facingRight)
                    {
                        cloneFlash = Instantiate(MuzzleFlash, startLoc.position, Quaternion.Euler(new Vector3(0, 0, angle + 180)));
                        Instantiate(banana, (startLoc.position), Quaternion.Euler(new Vector3(0, 0, angle)));

                    }
                    else
                    {
                        cloneFlash = Instantiate(MuzzleFlash, startLoc.position, Quaternion.Euler(new Vector3(0, 0, angle + 180)));
                        Instantiate(banana, (startLoc.position), Quaternion.Euler(new Vector3(0, 0, angle)));

                    }
                }
            }
        }

    }
}
