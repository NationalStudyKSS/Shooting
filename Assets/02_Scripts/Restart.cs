using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public void ActiveRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Play");
    }

    public void ActiveQuit()
    {
        Application.Quit();
    }
}
