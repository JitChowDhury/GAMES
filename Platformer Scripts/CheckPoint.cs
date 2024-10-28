using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public SpriteRenderer sr;
    public Sprite cpOn, cpOff;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CheckPointController.Instance.DeactivateCheckPoint();
            sr.sprite = cpOn;
            CheckPointController.Instance.setSpawnPoint(transform.position);
        }

    }
    public void resetCheckPoint()
    {
        sr.sprite=cpOff;
    }
}
