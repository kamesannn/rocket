using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    AudioSource ObstacleAudio;
    [SerializeField]
    AudioClip RocketHit;

    private void Start() {
        ObstacleAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {
        ObstacleAudio.PlayOneShot(RocketHit);
    }
}
