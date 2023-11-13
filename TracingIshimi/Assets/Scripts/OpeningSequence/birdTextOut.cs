using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class birdTextOut : MonoBehaviour
{
    public float time;
    public Text text;
    int num;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        num = (int)time;

        if (num > 12) {
            text.text = "요즘 우리 할아버지 밭에 새가 참 많다!";
        }

        if (num > 17) {
            text.text = "난 새가 참 좋아.";
        }

        if (num > 25) {
            text.text = "";
        }

        if (num > 30) {
            text.text = "할아버지가 논밭에 새가 많이 몰렸다고, 새를 쫓으러 나가보라고 했다.";
        }

        if (num > 35) {
            text.text = "신난다! 내일 아침에 어머니 아버지 몰래 빨리 나가봐야겠다!";
        }

    }

}