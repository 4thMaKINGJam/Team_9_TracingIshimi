using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject intro_panel;
    public GameObject conv_manager;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            intro_panel.SetActive(false);
            int[] character_data = {20,10,20,10,20,20};
            string[] dialog_data = {"어서오게, 자네가 이시미를 잡으러 온 그 사람인가?","그렇습니다.","그래, 여기가 바로 사람들이 잡아먹힌 현장일세.","... 정말 참혹하군요.","그 괴물이 보이는 족족 잡아먹어서,\n누구를 얼마나 잡아먹었는지도 알 수가 없다고 하더군.","이 주변을 샅샅이 살펴보다 보면 단서를 얻을 수도 있겠지."};
            conv_manager.GetComponent<ConvManager>().CallConversation(character_data, dialog_data, 4);
        }
        
    }
}
