using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("Level 4");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
