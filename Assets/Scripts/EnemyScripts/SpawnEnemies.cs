using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    RaycastHit2D rc, Reverserc;
    public GameObject enem;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void spawnEnemy(Collider2D coll, Collider2D playercoll)
    {
        //Spawn Enemies Before Player
        if (coll.tag == "EnemyTrigger")
        {
            int Layermask = ~((1 << 8) | (1 << 9) | (1 << 10) | (1 << 11) | (1 << 2) | (1 << 12) | (1 << 14) | (1 << 16));
            rc = Physics2D.Raycast(coll.transform.position, Vector2.right, Mathf.Infinity, Layermask);
     
            if (rc.collider != null && rc.collider.tag == "SpawnPoint")
            {
                Instantiate(enem, (new Vector3(rc.collider.transform.position.x, rc.collider.transform.position.y, 0)), Quaternion.Euler(new Vector3(0, 0, 0)));
                Destroy(coll.gameObject);
                Destroy(rc.collider.gameObject);
            }


        }

        //Spawn Enemies Behind Player
        if (coll.tag == "EnemyBackTrigger")
        {
            int Layermask = ~((1 << 8) | (1 << 9) | (1 << 10) | (1 << 11) | (1 << 2) | (1 << 12) | (1 << 16));
            Reverserc = Physics2D.Raycast(coll.transform.position, Vector2.left, Mathf.Infinity, Layermask);

            if (Reverserc.collider != null && Reverserc.collider.tag == "SpawnPoint")
            {
                Instantiate(enem, (new Vector3(Reverserc.collider.transform.position.x, Reverserc.collider.transform.position.y, 0)), Quaternion.Euler(new Vector3(180f, 0, 180f)));
                Destroy(coll.gameObject);
                Destroy(Reverserc.collider.gameObject);
            }

        }
    }
}
