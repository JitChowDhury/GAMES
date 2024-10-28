using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LSUI : MonoBehaviour
{   

    public static LSUI instance;

    public Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack, shouldFadeFromBlack;



    public GameObject levelinfoPanel;
    public TextMeshProUGUI levelName , gemsFound , gemsTotal , bestTime , TimeTarget;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        fadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        ScreenFade();
    }

    void ScreenFade()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
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

    public void fadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }
    public void fadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    public void showInfo(MapPoint levelinfo)
    {

        levelName.text = levelinfo.levelName;
        gemsFound.text = "FOUND: " + levelinfo.gemsCollected;
        gemsTotal.text = "IN LEVEL: " +levelinfo.totalGems;

        TimeTarget.text="TARGET: "+levelinfo.targetTime+ "s";

        if (levelinfo.bestTime == 0)
        {
            bestTime.text = "BEST:--------";

        }
        else
        {
            bestTime.text = "BEST: " + levelinfo.bestTime.ToString("F1") + "s";
        }

        levelinfoPanel.SetActive(true);
    }
    public void hideInfo() 
    { 
        levelinfoPanel.SetActive(false);

    }

}
