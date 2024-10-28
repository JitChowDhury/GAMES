using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{   
    public static PlayerHealthController Instance;
    public int currentHealth, maxHealth;

    public float invincibleLength;
    private float invincibleCounter;
    private SpriteRenderer SR;

    public GameObject deathEffect;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this; 
    }
    void Start()
    {
        currentHealth=maxHealth;
        SR=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -=Time.deltaTime;
            if(invincibleCounter <= 0)
            {
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1f);
            }
        }
    }
    public void DealDamage()
    {
        if (invincibleCounter <= 0) { 
        currentHealth--;
            AudioManager.instance.PlaySFX(3);

            if (currentHealth <= 0)
        {
            currentHealth = 0;

                //gameObject.SetActive(false);
                AudioManager.instance.PlaySFX(5);

                Instantiate(deathEffect , transform.position, transform.rotation);
            LevelManager.instance.respawnPlayer();
        }
        else
        {
            invincibleCounter=invincibleLength;
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, .5f);
                PlayerController.instance.knockBack();
        }

        UIController.Instance.updateHealthDisplay();
        }

    }
    public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.Instance.updateHealthDisplay();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent=collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }

}
