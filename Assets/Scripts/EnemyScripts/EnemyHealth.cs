using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float maxhealth, dropRate;
    float curhealth, random, randomPower;
    public GameObject death;
    public GameObject[] powerup;

	// Use this for initialization
	void Start () {
        curhealth = maxhealth;
	}
	
	// Update is called once per frame
	void Update () {
         random = Random.Range(0f, 100f);
        randomPower = Random.Range(0, powerup.Length);
    }

    public void addDamage(float damage)
    {
        curhealth -= damage;
        if (curhealth <= 0)
        {
            var deathOBJ = Instantiate(death, new Vector3(transform.position.x, transform.position.y, 1), Quaternion.Euler(new Vector3(-90, 0, 1)));
            Destroy(gameObject);
            Debug.Log(randomPower);
            if (random < dropRate)
                Instantiate(powerup[(int)randomPower], transform.position + new Vector3(0, 3, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            
        }
    }
}
