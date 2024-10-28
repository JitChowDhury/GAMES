using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    public GameObject deathEffect;

    public GameObject collectible;

    [Range(0,100)]public float chanceToDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect , collision.transform.position,collision.transform.rotation);
            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0f, 100f);

            if (dropSelect <= chanceToDrop) 
            { 
              Instantiate(collectible,collision.transform.position , collision.transform.rotation);
                
              
            }
            AudioManager.instance.PlaySFX(0);

        }
    }
}
