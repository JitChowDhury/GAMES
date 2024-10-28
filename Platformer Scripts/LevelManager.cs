using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{    
    public static LevelManager instance;
    public float waitToRespawn;
    public int gemsCollected;
    public float timeInLevel; 

    public string levelToLoad;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timeInLevel = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime; 
    }
    public void respawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

   private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn-(1f / UIController.Instance.fadeSpeed));
        UIController.Instance.fadeToBlack();

        yield return new WaitForSeconds((waitToRespawn-1f/UIController.Instance.fadeSpeed)+.2f);
        UIController.Instance.fadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckPointController.Instance.spawnPoint;
        PlayerHealthController.Instance.currentHealth = PlayerHealthController.Instance.maxHealth;
        UIController.Instance.updateHealthDisplay();


    }

    public void EndLevel()
    {
        StartCoroutine (EndLevelCo());
    }
    private IEnumerator EndLevelCo()
    {
        AudioManager.instance.PlayLevelVictory(); 
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;

        UIController.Instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        UIController.Instance.fadeToBlack();

        yield return new WaitForSeconds((1f / UIController.Instance.fadeSpeed) + 2f);


        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked" , 1);
        PlayerPrefs.SetString("CurrentLevel" , SceneManager.GetActiveScene().name);
       
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
            {
            if(gemsCollected> PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
        }

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
        else {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }

        
        SceneManager.LoadScene(levelToLoad);
    }
}
