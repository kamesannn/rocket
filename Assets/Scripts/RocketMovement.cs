using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketMovement : MonoBehaviour
{
    Rigidbody RocketRB;
    AudioSource RocketSound;
    [SerializeField]
    AudioClip RocketEngine;

    float RocketSpeed = 1000;
    float RotationSpeed = 100;

    void Start()
    {
        //Getting reference to components in the prefab
        RocketRB = GetComponent<Rigidbody>(); 
        RocketSound = GetComponent<AudioSource>();

        RocketSound.Stop();
    }


    void Update() {
        ProcessMovement();
        ProcessRotation();
    }

    private void ProcessRotation() {
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

    private void ProcessMovement() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            //Add upwards direction to force, multiply by time difference, multiply by a speed variable.
            RocketRB.AddRelativeForce(Vector3.up * Time.deltaTime * RocketSpeed);

            if (!RocketSound.isPlaying) {
                //RocketSound.Play();
                RocketSound.PlayOneShot(RocketEngine);
            }
        }
        else {
            RocketSound.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        
        string CollisionTag = collision.gameObject.tag;

        switch (CollisionTag) {
            case "Finish":
                Debug.Log("You Won...");
                LoadNextLevel();
                break;

            case "Obstacle":
                Debug.Log("Hit obstacle....");
                break;

            case "GameOver":
                ReloadLevel();
                Debug.Log("Game over...");
                break;
        }
    }

    private void ReloadLevel() {
        int LevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(LevelIndex);
    }

    private void LoadNextLevel() {
        int LevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(LevelIndex + 1); // build index +1 to load next level
        
    }
}
