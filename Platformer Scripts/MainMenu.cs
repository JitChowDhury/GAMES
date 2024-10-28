using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string startScene , continueScene;
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(startScene + "_unlocked"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        SceneManager.LoadScene(startScene);
        PlayerPrefs.DeleteAll();
    }

    public void continueGame()
    {
        SceneManager.LoadScene(continueScene);
    }
    public void quitGame()
    {
         Application.Quit();
    }
}
