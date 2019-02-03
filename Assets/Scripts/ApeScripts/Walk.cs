using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Walk : MonoBehaviour {
    public Animator anim;

    public bool poweredUp;
    [HideInInspector]
    public float canPick;

    //Audio
    public GameObject health;
    public bool didpick = false;

    public string axname;
public float speed;
public Rigidbody2D RB;
Collider2D coll;

public bool facingRight, canWalk;

    //Jumping
    public bool grounded = false;
public Transform GroundCheck;
public float CheckRadius;
public LayerMask ground;
public float JumpForce;
    public GameObject jumpSound;

public GameObject gunArm;

//Ladder Climb
public bool ClimbPossible = false, isClimbing = false;
float ogGravity;
float climbVelocity;
float climbSpeed = 6;
 public  GameObject TheGround;
    [SerializeField]
    private Collider2D groundCollider;
    //Power Up
    public SpriteRenderer gun;
    public Sprite[] weapons;

//Raycast
RaycastHit2D rc, Reverserc;

    //Enemy Spawn
    SpawnEnemies spawn;


// Use this for initialization
void Start () {
        spawn = FindObjectOfType<SpawnEnemies>();

anim = GetComponent<Animator>();
RB = GetComponent<Rigidbody2D>();
ogGravity = RB.gravityScale;

facingRight = true;
poweredUp = false;
canPick = 0;

//Player doesn't collide with enemies
Physics2D.IgnoreLayerCollision(9, 10, true);
Physics2D.IgnoreLayerCollision(9, 11, true);

}

void FixedUpdate()
{
Vector3 newScale;

        if(canWalk)
transform.position += transform.right * Input.GetAxis(axname) * speed * Time.deltaTime;
//  transform.position += transform.up * Input.GetAxis("Vertical") * speed * Time.deltaTime;

if (Convert.ToBoolean(Input.GetAxis(axname)))
{
anim.SetBool("walk", true);
            if(grounded == true)
            this.gameObject.GetComponent<AudioSource>().mute = false;
            else
                this.gameObject.GetComponent<AudioSource>().mute = true;
        }
        else 
{
anim.SetBool("walk", false);
            this.gameObject.GetComponent<AudioSource>().mute = true;
        }

        if (Input.GetAxis(axname) < 0 && !isClimbing)
{
facingRight = false;
while(transform.localScale.x > 0)
{
newScale = transform.localScale;
newScale.x = -1 * newScale.x;
transform.localScale = newScale;
}
}

if(Input.GetAxis(axname) > 0 && !isClimbing)
{
facingRight = true;
while(transform.localScale.x < 0)
{
newScale = transform.localScale;
newScale.x = -1 * newScale.x;
transform.localScale = newScale;
}
}

        //Check if character is grounded
        if (!isClimbing)
            grounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, ground);
        else
            grounded = false;
}

    // Update is called once per frame
    void Update()
    {
        if (isClimbing == true)
            gunArm.SetActive(false);
        else
            gunArm.SetActive(true);

        if (didpick)
        {
            health.GetComponent<AudioSource>().Play();
            didpick = false;
        }
        //JUMP

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
     grounded = false;
            RB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            StartCoroutine(jump());
        }

        if (grounded == false && RB.gravityScale != 0)
        {
            anim.SetBool("jump", true);
        }
        else  
        {
          anim.SetBool("jump", false);
        }

        //Ladder Climb  
        if (ClimbPossible == true)
        {
            Physics2D.IgnoreCollision(groundCollider, this.GetComponent<Collider2D>(), true);



            if (Input.GetButtonDown("Vertical"))
            {
                isClimbing = true;
                RB.gravityScale = 0;
                RB.constraints = RigidbodyConstraints2D.FreezePositionX;
                //TheGround.GetComponent<Collider2D>().isTrigger = true;
                anim.SetBool("climb", true);
                anim.SetBool("jump", false);
                // RB.velocity = new Vector2(0, 1);
            }

            if (!Input.GetButton("Vertical") && RB.gravityScale == 0)
            {
                RB.constraints = RigidbodyConstraints2D.FreezeAll;
                anim.SetBool("staticLadder", true);
                if(RB.gravityScale == 0)
                {
                   // RB.velocity = new Vector2(0, 1);
                }
            }
            else
            {
                RB.constraints = RigidbodyConstraints2D.None;
                RB.constraints = RigidbodyConstraints2D.FreezeRotation;
                if (Input.GetAxis("Vertical") > 0)
                {
                    RB.velocity = new Vector2(0, speed);
                }
                else
                if (Input.GetAxis("Vertical") < 0)
                {
                    RB.velocity = new Vector2(0, -speed);
                }
               
                //  transform.position += transform.up * Input.GetAxis("Vertical") * speed * Time.deltaTime;
                anim.SetBool("staticLadder", false);
                anim.SetBool("climb", true);
            }

            if (grounded == true)
                {
                    anim.SetBool("climb", false);
                }
            
        }
        else
        {
            isClimbing = false;
            gunArm.SetActive(true);
            Physics2D.IgnoreCollision(groundCollider, this.GetComponent<Collider2D>(), false);
            RB.gravityScale = ogGravity;
            //TheGround.GetComponent<Collider2D>().isTrigger = false;
            anim.SetBool("climb", false);
            anim.SetBool("staticLadder", false);
            RB.constraints = RigidbodyConstraints2D.None;
            RB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }


    }

   

void OnTriggerEnter2D(Collider2D coll)
{
if (coll.tag == "PowerUpA")
{
poweredUp = true;
canPick = Time.time;
Destroy(coll.gameObject);
//anim.SetBool("PoweredUpA", true);
            gun.sprite = weapons[1];
}

        //Spawn Enemies Before Player
        spawn.spawnEnemy(coll, this.GetComponent<Collider2D>());

}

void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Respawn")
        {
            if (ClimbPossible == true)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
            }
          
        }
    }

    IEnumerator jump()
    {
        jumpSound.SetActive(true);
        yield return new WaitForSeconds(.4f);
        jumpSound.SetActive(false);
    }

}
