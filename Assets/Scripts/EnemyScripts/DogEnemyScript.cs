using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogEnemyScript : MonoBehaviour {

    //Rigidbody2D rb;
    public float EnemySpeed;
    public float damage;
    public float lifespan;
    public GameObject dog;
    EnemyHealth health;

    void Awake()
    {
        Destroy(dog, lifespan);
    }
	// Use this for initialization
	void Start () {
        health = FindObjectOfType<EnemyHealth>();

    }

    // Update is called once per frame
    void Update () {
        if(dog.transform.localRotation.z <= 0)
            dog.transform.position += dog.transform.right * -1 * EnemySpeed * Time.deltaTime;
        else
            dog.transform.position += dog.transform.right * EnemySpeed * Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            Debug.Log(dog.transform.localRotation.z);
            if (dog.transform.localRotation.z < 0)
                dog.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            else
                dog.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        if (coll.tag == "Player")
        {
            ApeHealth ape = coll.gameObject.GetComponent<ApeHealth>();
            ape.AddDamage(damage);
        }
    }


}
