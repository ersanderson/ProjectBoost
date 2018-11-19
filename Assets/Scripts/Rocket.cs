using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Thrust()
    {
        float thrustThisFrame = mainThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            print("Thrusting"); // can thrust while rotating
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
            print("Rocket Rotate LEFT");
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("Rocket Rotate RIGHT");
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
    }

    
}

