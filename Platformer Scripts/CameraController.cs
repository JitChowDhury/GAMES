using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform target;
    public Transform farbackground, middlebackground, forebackground;
    //private float lastXpos;
    private Vector2 lastpos;
    public float minHeight, maxHeight;

    public bool stopFollow;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //lastXpos = transform.position.x;
        lastpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.position = new Vector3(target.position.x , target.position.y , transform.position.z);

        float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        */
        if (!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
            //float amountToMoveX=transform.position.x-lastXpos;
            Vector2 amountToMove = new Vector2(transform.position.x - lastpos.x, transform.position.y - lastpos.y);


            farbackground.position = farbackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
            middlebackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;
            forebackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .25f;
            lastpos = transform.position;
        }
    }   
}
