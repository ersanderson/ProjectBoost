using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

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
        if (Input.GetKey(KeyCode.Space))
        {
            print("Thrusting"); // can thrust while rotating
            rigidBody.AddRelativeForce(Vector3.up);
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

        if (Input.GetKey(KeyCode.A))
        {
            print("Rocket Rotate LEFT");
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("Rocket Rotate RIGHT");
            transform.Rotate(-Vector3.forward);
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
    }

    
}

