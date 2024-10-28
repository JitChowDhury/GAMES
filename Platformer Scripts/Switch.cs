using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject objectToSwitch;
    private SpriteRenderer sr;
    public Sprite downSprite;
    private bool hasSwitched;
    // Start is called before the first frame update
    void Start()
    {
       sr=GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !hasSwitched)
        {
            objectToSwitch.SetActive(false);
            sr.sprite = downSprite;
            hasSwitched = true;
        }
    }
}
