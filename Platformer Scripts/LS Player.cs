using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{

    

    public MapPoint currentPoint;
    public float moveSpeed = 10f;

    private bool levelLoading;

    public LSManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position = Vector3.MoveTowards(transform.position , currentPoint.transform.position, moveSpeed*Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f && !levelLoading)
        {


            if (Input.GetAxisRaw("Horizontal") > .5f)
            {
                if (currentPoint.right != null)
                {
                    setNextPoint(currentPoint.right);


                }
            }

            if (Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if (currentPoint.left != null)
                {
                    setNextPoint(currentPoint.left);
                }
            }

            if (Input.GetAxisRaw("Vertical") > .5f)
            {
                if (currentPoint.up != null)
                {
                    setNextPoint(currentPoint.up);


                }
            }

            if (Input.GetAxisRaw("Vertical") < -.5f)
            {
                if (currentPoint.down != null)
                {
                    setNextPoint(currentPoint.down);
                }
            }

            if (currentPoint.isLevel && currentPoint.levelToLoad !="" && !currentPoint.islocked)
            {
                LSUI.instance.showInfo(currentPoint);

                if (Input.GetButtonDown("Jump"))
                {
                    levelLoading = true;
                    manager.LoadLevel();
                }
            }
        }
    } 

    void setNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
        LSUI.instance.hideInfo();
        AudioManager.instance.PlaySFX(8);
    }
}
