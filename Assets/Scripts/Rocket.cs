using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;


    Rigidbody rigidBody;
    AudioSource rocketThrustSound;
    
    // Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rocketThrustSound = GetComponent<AudioSource>();
        rocketThrustSound.Stop();

    }
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Rocket Collided");
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //do nothing
                break;
            case "Finish":
                print("Hit Finish");
                SceneManager.LoadScene(1);
                break;
            default:
                print("X DEAD X");
                SceneManager.LoadScene(0);
                //Kill the Player
                break;

        }
    }


    private void Thrust()
    {
        float thrustThisFrame = mainThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
          
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);
            if (!rocketThrustSound.isPlaying)
            {
                rocketThrustSound.Play();
            }
        }
        else
        {
            rocketThrustSound.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation

       
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
         
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
    }

    
}

