using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody RocketRB;

    float RocketSpeed = 1000;
    float RotationSpeed = 100;

    void Start()
    {
        RocketRB = GetComponent<Rigidbody>(); //Getting reference to Rigidbody in the gameobject
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)) {
            //Add upwards direction to force, multiply by time difference, multiply by a speed variable.
            RocketRB.AddRelativeForce(Vector3.up * Time.deltaTime * RocketSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            //Turn off rigidbody rotation to not intefere with object rotation
            RocketRB.freezeRotation = false;
            //Add rotation to the object 
            transform.Rotate(Vector3.left * Time.deltaTime * RotationSpeed);
            //Turn on rigidbody rotation
            RocketRB.freezeRotation = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            RocketRB.freezeRotation = false;
            transform.Rotate(Vector3.right * Time.deltaTime * RotationSpeed);
            RocketRB.freezeRotation = true;
        }

    }

    private void OnCollisionEnter(Collision collision) {
        
    }
}


            //TODO try the following code
            //RocketRB.AddForce(Vector3.up * Time.deltaTime * RocketSpeed);