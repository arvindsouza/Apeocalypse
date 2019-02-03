using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliScript : MonoBehaviour {

    public float speed;
    Vector3 initpos;

	// Use this for initialization
	void Start () {
        initpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < 14)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            StartCoroutine(delay());
        }
	}

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        transform.position = initpos;
    }
}


