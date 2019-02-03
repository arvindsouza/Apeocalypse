using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {

    public bool won = false;
    bool played = false;
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (won)
        {
            StartCoroutine(delay());
        }
	}

    IEnumerator delay()
    {
        yield return new WaitForSeconds(4f);
        if (transform.position.y > transform.position.y - 20)
        {
            transform.position += transform.up * -1 * 3 * Time.deltaTime;
        }
        if(!played)
        GetComponent<AudioSource>().Play();
        played = true;
    }
}
