using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class josunTextOut : MonoBehaviour
{
    public Text text;
    public float time;
    int num;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        num = (int)time;

        if (num == 8) {
            text.text = "";
        }
    }


}