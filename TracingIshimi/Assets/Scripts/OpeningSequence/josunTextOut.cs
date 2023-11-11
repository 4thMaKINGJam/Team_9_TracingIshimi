using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class josunTextOut : MonoBehaviour
{
    public GameObject talk_panel;
    public float time;
    public Text text;
    int num;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        num = (int)time;

        if (num == 5) {
            text.text = "";
        }
    }


}