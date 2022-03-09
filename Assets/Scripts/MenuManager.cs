using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Method to be called from Button onclick event in Unity
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
}
