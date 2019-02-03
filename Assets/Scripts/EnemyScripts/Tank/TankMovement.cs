using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

    public float speed;
    public GameObject turretLeft, turretRight, laser, levelManager, exitdoor;
    public GameObject[] destroyObj;
    bool turretsDown = false, canMove = true;
    public bool won = false;
    WinScript winCondition;

	// Use this for initialization
	void Start () {
        winCondition = FindObjectOfType<WinScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.localScale.x > 0 && canMove)
        transform.position += Vector3.right * -1 * Time.deltaTime * speed;
        else if(transform.localScale.x < 0 && canMove)
            transform.position += Vector3.right * Time.deltaTime * speed;

        if (turretLeft == null || turretRight == null)
            turretsDown = true;

        if(turretsDown == true)
        {
            if(laser != null)
            laser.SetActive(true);
        }

        if (turretLeft == null && turretRight == null && laser == null)
        {
            if(winCondition.won == false)
            StartCoroutine(destroy());
            winCondition.won = true;
        }

    }

    public IEnumerator destroy()
    {
        canMove = false;
        GetComponent<Animator>().enabled = false ;
        levelManager.GetComponent<AudioSource>().Pause();
        yield return new WaitForSeconds(.5f);
        foreach (GameObject explosion in destroyObj)
        {
          var explode =   Instantiate(explosion, this.transform.position + new Vector3(Random.Range(1, 5), Random.Range(1, 5), 0), Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(.2f);
        }
        yield return new WaitForSeconds(.5f);
        var obj = Instantiate(destroyObj[destroyObj.Length - 1], this.transform.position + new Vector3(2,0,0), Quaternion.Euler(0, 0, 0));
        obj.transform.localScale = new Vector3(100, 100, 1);
        Destroy(this.gameObject);
        /*  for(int i = 0; i < 10; i++)
          {
              Instantiate(destroyObj, this.transform.position + new Vector3(Random.Range(i, i+5), Random.Range(i, i + 5), 0), Quaternion.Euler(0, 0, 0));
          }*/

    }
}
