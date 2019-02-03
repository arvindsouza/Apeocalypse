using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Congratulations : MonoBehaviour {

    public GameObject gameover, text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            Destroy(coll.gameObject);
            text.GetComponent<Text>().text = "Congratulations! Now fuck off!";
            //text.GetComponent<Text>().fontSize = 20;
            text.GetComponent<Text>().color = new Color(41, 195,11,255);
            gameover.SetActive(true);
        }
    }
}
