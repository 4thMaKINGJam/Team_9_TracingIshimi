using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIfadein : MonoBehaviour
{
    public GameObject cutScene;
    SpriteRenderer sr;
    public float time;
    int num;

    void Start() {
        sr = cutScene.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        num = (int)time;

        if (num > 47) {
            sr.material.color = Color.black;
        }

    }
}