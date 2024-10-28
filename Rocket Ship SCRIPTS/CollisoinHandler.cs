using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisoinHandler : MonoBehaviour
{

    [SerializeField] AudioClip Explosion;
    [SerializeField] AudioClip Success;

    [SerializeField] ParticleSystem ExplosionParticle;
    [SerializeField] ParticleSystem SuccessParticle;

    [SerializeField] float loadNextDelay = 2f;

    AudioSource audioSource;

    bool isTransitioning=false;
    bool collisoinDisable=false;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {

            nextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C)) {
        collisoinDisable = !collisoinDisable;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isTransitioning || collisoinDisable) return;
        switch (collision.gameObject.tag) {
            case "Friendly":

                break;
            case "Finish":
                startSuccessSequence();

                break;
            case "Fuel":


                break;
            default:
                Debug.Log("BLEW UP");
                startCrashSequence();
                break;




        }
    }

    private void startSuccessSequence()
    { 
        audioSource.Stop();
        SuccessParticle.Play();
        audioSource.PlayOneShot(Success);
        GetComponent<Movement>().enabled=false;
        Invoke("nextLevel" , loadNextDelay);
        isTransitioning = true;
    }

    void startCrashSequence()
    {
        ExplosionParticle.Play();
        audioSource.PlayOneShot(Explosion);
        GetComponent<Movement>().enabled = false;
        isTransitioning = true;


        Invoke("ReloadLevel", loadNextDelay);
    }

    void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void nextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex=currentSceneIndex+1;
        if (nextSceneIndex>= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        ;
        SceneManager.LoadScene(nextSceneIndex);
    }

  
    

}
