using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ImageRestart;
    void Start()
    {
        ImageRestart.SetActive(false);
    }
    public void onClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
