using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        
		
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Thrusting"); // can thrust while rotating
            rigidBody.AddRelativeForce(Vector3.up);
            
        }

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
    }
}
