using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour {

    public string text, textB;
    int counter = 0, othercounter=0;
    public GameObject topBar, botBar, Ape, Eyes, Lightning, sign, house, ground, thunder;

	// Use this for initialization
	void Start () {
        StartCoroutine(openingText());
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Text>().text.Contains("themselves") && othercounter == 0)
        {
            StartCoroutine(secondScene());
        }
        if(othercounter == 2)
        {
            StartCoroutine(SecondText());

        }

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator openingText()
    {
        foreach(char letter in text)
        {
            GetComponent<Text>().text += letter;
            if (GetComponent<Text>().text.Contains("...."))
            {
                if (!GetComponent<Text>().text.Contains(".B"))
                {
                    counter++;
                    if(counter <=1)
                    GetComponent<Text>().text += System.Environment.NewLine;
                }
            }
            
          //  
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator secondScene()
    {
        ++othercounter;
        Debug.Log("A");
        yield return new WaitForSeconds(.5f);
        topBar.GetComponent<Animator>().enabled = true;
        botBar.GetComponent<Animator>().enabled = true;
        sign.GetComponent<Animator>().enabled = true;
        house.GetComponent<Animator>().enabled = true;
        ground.GetComponent<Animator>().enabled = true;
        Ape.GetComponent<Animator>().SetTrigger("zoom");
        thunder.SetActive(true);
        yield return new WaitForSeconds(.6f);
       // yield return new WaitForSeconds(.2f);
        GetComponent<Text>().text = " ";
        Lightning.SetActive(true);
        yield return new WaitForSeconds(.12f);
        Eyes.SetActive(true);
        ++othercounter;
    }

    IEnumerator SecondText()
    {
        ++othercounter;
        this.GetComponent<RectTransform>().localPosition = new Vector3(36, -129, 0.1f);
        Debug.Log(this.GetComponent<RectTransform>().localPosition);
        foreach (char letter in textB)
        {
            GetComponent<Text>().text+= letter;
               if (GetComponent<Text>().text.Contains("pay."))
               {
                   if (!GetComponent<Text>().text.Contains(".g"))
                   {
                       counter++;
                       if (counter <= 40)
                       {
                           GetComponent<Text>().text += System.Environment.NewLine;
                      //  GetComponent<Text>().text += System.Environment.NewLine;
                        yield return new WaitForSeconds(.3f);
                       }
                   }
               }            
            yield return new WaitForSeconds(.2f);
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }
}
