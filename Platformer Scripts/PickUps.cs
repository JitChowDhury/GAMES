using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{

    public bool isGem, isHeal;
    private bool isCollected;
    public GameObject PickupEffect;
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
        if (collision.CompareTag("Player")&& !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;
                isCollected = true;
                Destroy(gameObject);
                Instantiate(PickupEffect , transform.position , transform.rotation) ;

                UIController.Instance.updateGemCount();
                AudioManager.instance.PlaySFX(1);
                
            }
            if (isHeal)
            {
                if (PlayerHealthController.Instance.currentHealth != PlayerHealthController.Instance.maxHealth)
                {
                    PlayerHealthController.Instance.HealPlayer();

                    Destroy(gameObject);
                    Instantiate(PickupEffect, transform.position, transform.rotation);
                    AudioManager.instance.PlaySFX(2);


                }
            }
        }
    }
}
