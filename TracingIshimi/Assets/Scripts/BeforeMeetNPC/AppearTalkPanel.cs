using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AppearTalkPanel : MonoBehaviour
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

        switch (num) {
            case 10:
            {
                text.text = "저게 뭐지?";
                break;
            }
            case 12:
            {
                text.text = "집이 완전히 풍비박산이 났네. 사람들이 이시미에게 변을 당한 곳이 저기인가...";
                break;
            }
            case 15:
            {
                text.text = "가서 살펴보자.";
                break;
            }
            case 16:
            {
                talk_panel.SetActive(false);
                break;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            talk_panel.SetActive(true);
        }
    }



}