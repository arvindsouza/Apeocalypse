using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {


    public Transform target;
    public bool canMove = true;
    public float smooth;
    Vector3 offset;
    float highy;

    // Use this for initialization
    void Start()
    {
        canMove = true;
        offset = transform.position - target.position;
        //target = GetComponent<Transform> ();
      //  lowy = transform.position.y;
        //highy  = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target && canMove)
        {
            Vector3 camerapos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, camerapos, smooth * Time.deltaTime);
        }


    }
}
