using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileCreate : MonoBehaviour{

    public float damage, ProjectileSpeed;
    Rigidbody2D rb;
    private ApeHealth AHealth;
    private GunScript gun;
    private Vector3 rangeTop, rangeBot, screenEnd,screenStart, rangeUp, initPos;

    // Use this for initialization
    void Start () {
        gun = FindObjectOfType<GunScript>();
        initPos = transform.position;
        if (GetComponent<Rigidbody2D>() != null)
        {
            rb = GetComponent<Rigidbody2D>();
            if (tag == "PlayerProjectile")
            {
                rb.AddForce(transform.right * ProjectileSpeed, ForceMode2D.Impulse);
                /* rangeTop = gun.playerPos + new Vector3(-5, 10, 0);
                 rangeBot = gun.playerPos + new Vector3(5, 10, 0);
                 screenStart = gun.playerPos;
                 float intercepta = rangeTop.y - ((rangeTop.y - screenStart.y) / (rangeTop.x - screenStart.x)) * rangeTop.x;
                 float interceptb = rangeBot.y - ((rangeBot.y - screenStart.y) / (rangeBot.x - screenStart.x)) * rangeBot.x;
                 float linea = gun.mousePos.y - ((rangeTop.y - screenStart.y) / (rangeTop.x - screenStart.x)) * gun.mousePos.x - intercepta;
                 float lineb = gun.mousePos.y - ((rangeBot.y - screenStart.y) / (rangeBot.x - screenStart.x)) * gun.mousePos.x - interceptb;
                 float mouseval = linea * lineb;

                 if (Input.GetAxis("Vertical") > 0 || mouseval > 0)
                  {
                      rb.AddForce(new Vector2(0, 1) * ProjectileSpeed, ForceMode2D.Impulse);

                 }
                 else
                  {
                     if (transform.localRotation.z >= 0)
                     {
                         rangeTop =  gun.playerPos + new Vector3(5, 10, 0);
                         rangeBot = gun.playerPos + new Vector3(5, 2, 0);
                         screenStart = gun.playerPos;
                         float interceptA = rangeTop.y - ((rangeTop.y - screenStart.y) / (rangeTop.x - screenStart.x)) * rangeTop.x;
                         float interceptB = rangeBot.y - ((rangeBot.y - screenStart.y) / (rangeBot.x - screenStart.x)) * rangeBot.x;
                         float lineA = gun.mousePos.y - ((rangeTop.y - screenStart.y) / (rangeTop.x - screenStart.x)) * gun.mousePos.x - interceptA;
                         float lineB = gun.mousePos.y - ((rangeBot.y - screenStart.y) / (rangeBot.x - screenStart.x)) * gun.mousePos.x - interceptB;
                         float mouseVal = lineA * lineB;

                         if (mouseVal < 0)
                         {
                             rb.AddForce(new Vector2(1, 1) * ProjectileSpeed, ForceMode2D.Impulse);
                         }
                         else
                          rb.AddForce(new Vector2(1, 0) * ProjectileSpeed, ForceMode2D.Impulse);
                      }
                      else
                                           if (transform.localRotation.z <= 0)
                     {
                         rangeTop = gun.playerPos +new Vector3(-5, 10, 0);
                         rangeBot = gun.playerPos +new Vector3(-5, 2, 0);
                         screenStart = gun.playerPos;
                         float interceptA = rangeTop.y - ((rangeTop.y - screenStart.y) / (rangeTop.x - screenStart.x)) * rangeTop.x ;
                         float interceptB =  rangeBot.y - ((rangeBot.y - screenStart.y) / (rangeBot.x - screenStart.x)) * rangeBot.x ;
                         float lineA = gun.mousePos.y - ((rangeTop.y - screenStart.y) / (rangeTop.x - screenStart.x)) * gun.mousePos.x - interceptA;
                         float lineB = gun.mousePos.y - ((rangeBot.y - screenStart.y) / (rangeBot.x - screenStart.x)) * gun.mousePos.x - interceptB;
                         float mouseVal = lineA * lineB ;

                         if (mouseVal < 0)
                         {
                             rb.AddForce(new Vector2(-1, 1) * ProjectileSpeed, ForceMode2D.Impulse);
                         }
                         else
                             rb.AddForce(new Vector2(-1, 0) * ProjectileSpeed, ForceMode2D.Impulse);
                      }
                  }*/

            }
            else
            {
                /*if (transform.localRotation.z >= 0 )
                {
                   // rb.AddForce(new Vector2(1, 0) * ProjectileSpeed, ForceMode2D.Impulse);
                }
                else*/
                {
                    rb.AddForce(transform.up * ProjectileSpeed, ForceMode2D.Impulse);
                }
            }

        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Enemy" && this.tag != "EnemyProjectile")
        {
          //  Debug.Log(coll.tag);
            EnemyHealth enem = coll.gameObject.GetComponent<EnemyHealth>();
            enem.addDamage(damage);
        }

        if(coll.tag == "Player" && this.tag != "PlayerProjectile")
        {
            ApeHealth ape = coll.gameObject.GetComponent<ApeHealth>();
            ape.AddDamage(damage);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" && this.tag != "EnemyProjectile")
        {
            //  Debug.Log(coll.tag);
            EnemyHealth enem = coll.gameObject.GetComponent<EnemyHealth>();
            enem.addDamage(damage);
        }

        if (coll.gameObject.tag == "Player" && this.tag != "PlayerProjectile")
        {
            ApeHealth ape = coll.gameObject.GetComponent<ApeHealth>();
            ape.AddDamage(damage);
        }
    }


}
