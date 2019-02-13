using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {

    public void OnNormalButtonDown() {
        SceneManager.LoadScene(1);
    }

    public void OnEndlessButtonDown() {
        SceneManager.LoadScene(4);
    }

    public void OnExitButtonDown() {
        Application.Quit();
    }
}
