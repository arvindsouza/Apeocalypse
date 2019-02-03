using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApeHealth : MonoBehaviour {

    public float MaxHealth;
    public float curHealth, hitTime=0, prevHitTime=0;
    private Health HUDHealth;
    [SerializeField]
    GameObject gameover;
    Walk player;

    private LevelManager level;

    // Use this for initialization
    void Start()
    {
        curHealth = MaxHealth;
        level = FindObjectOfType<LevelManager>();
        HUDHealth = FindObjectOfType<Health>();
        player = FindObjectOfType<Walk>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator Delay()
    {
        Debug.Log("test");

        /* flicker after hit */

        for(int i=0;i<3;i++)
        {
            player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            player.gunArm.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(.1f);
            player.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            player.gunArm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(.1f);
        }

    }

    public void AddDamage(float damaged)
    {
        hitTime = Time.time;
        if(prevHitTime == 0)
        {
            curHealth -= damaged;
            StartCoroutine(Delay());
            prevHitTime = hitTime;
        }
        else
if(hitTime >= prevHitTime + .8f )
        {
            curHealth -= damaged;
            StartCoroutine(Delay());
            prevHitTime = hitTime;
        }

        //  Debug.Log(curHealth);
        if (curHealth <= 0)
        {
                curHealth = 0;
            gameover.SetActive(true);
            Destroy(this.gameObject);
        //    SceneManager.LoadScene("Level1");
          //  level.RespawnPlayer();
        }
        HUDHealth.updateHearts();
        StartCoroutine(HUDHealth.toggleFaces(1));
            
    }

    public void addHealth(float health)
    {
        if(curHealth < MaxHealth)
        {
            if(curHealth + health > MaxHealth)
            {
                curHealth = MaxHealth;
            }
            else
            curHealth += health;
        }
        HUDHealth.updateHearts();
    }



}
