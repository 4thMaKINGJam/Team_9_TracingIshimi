using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
                SceneManager.LoadScene("FindHint");
        }
    }



}