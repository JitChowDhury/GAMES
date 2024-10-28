using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //PARAMETRES - for tuning , typically set in the editor

    //CACHE - e.g references for readability or speed

    //STATE - private instance (member) variables

    [SerializeField] float ThrustForce = 100f;
    public float RotationForce = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticle;

    Rigidbody rigidBody;
    AudioSource SFX;

    bool isAlive;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        SFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        

    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            startThrusting();
        }

        else
        {
            NewMethod();

        }
    }

    private void NewMethod()
    {
        SFX.Stop();
        mainEngineParticle.Stop();
    }

    private void startThrusting()
    {
        rigidBody.AddRelativeForce(Vector3.up * ThrustForce * Time.deltaTime);
        if (!SFX.isPlaying)
        {
            SFX.PlayOneShot(mainEngine);
        }

        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(RotationForce);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-RotationForce);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {

        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false;

    }

   
}
