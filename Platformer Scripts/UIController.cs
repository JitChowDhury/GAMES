using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    public static UIController Instance;
    public Image heart1, heart2, heart3;
    public Sprite heartFull,heartHalf ,  heartEmpty;
    public TextMeshProUGUI gemText;
    public Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack, shouldFadeFromBlack;
    public GameObject levelCompleteText;












    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        updateGemCount();
        fadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
         ScrenFade();


    }

    void ScrenFade()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color=new Color(fadeScreen.color.r , fadeScreen.color.g , fadeScreen.color.b , Mathf.MoveTowards(fadeScreen.color.a ,1f , fadeSpeed*Time.deltaTime ) );
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
        if (shouldFadeFromBlack)
        {
            {
                fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
                if (fadeScreen.color.a == 0f)
                {
                    shouldFadeFromBlack = false;
                }
            }
        }
    }



    public void updateHealthDisplay()
    {
        switch (PlayerHealthController.Instance.currentHealth)
        {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                break;
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                break;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
           
        }

    }
    public void updateGemCount()
    {
        gemText.text = LevelManager.instance.gemsCollected.ToString();
    }

    public void fadeToBlack()
    {
        shouldFadeToBlack=true;
        shouldFadeFromBlack = false;
    }
    public void fadeFromBlack()
    {
        shouldFadeFromBlack=true;
        shouldFadeToBlack=false;
    }


}
