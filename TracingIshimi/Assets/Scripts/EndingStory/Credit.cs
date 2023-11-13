using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Credit : MonoBehaviour
{
    public TMP_Text END_text;
    public GameObject panel_end;
    public GameObject panel_back;
    public void showCredit(){
        panel_back.SetActive(true);
        panel_end.SetActive(true);
        END_text.text = "제 4회 메이킹잼\n프로젝트 - 이시미잡이\n\n- 기획 및 사운드 -\n<color=\"grey\">한국음악과</color>\n한이새꽃\n\n- 그래픽 -\n<color=\"grey\">섬유예술과</color>\n이주원\n\n- 코더 -\n<color=\"grey\">컴퓨터공학전공</color>\n김정민\n\n김현민\n\n이소민";
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,-500f);
        panel_end.GetComponent<Image>().color = new Color(0,0,0,1);
    }
    void Update(){
        if(gameObject.GetComponent<RectTransform>().anchoredPosition.y<=5000){
            if(panel_end.GetComponent<Image>().color.a>0){
                Color color = panel_end.GetComponent<Image>().color;
                panel_end.GetComponent<Image>().color = new Color(0,0,0, color.a -=0.005f);
            }
            else{
                panel_end.SetActive(false);
            }
         float posY = gameObject.GetComponent<RectTransform>().anchoredPosition.y;
         gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,posY+2f);
        }
    }
}
