using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ImageRestart;
    void Start()
    {
        if (ImageRestart != null)
            ImageRestart.SetActive(false);
    }
    public void onClickRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void onClickStart()
    {
        SceneManager.LoadScene("TracingIshimi");
    }
}
