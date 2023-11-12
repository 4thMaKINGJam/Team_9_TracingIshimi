using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingIntro : MonoBehaviour
{
    public EndingStorySoundManager soundManager;
    bool is_texteff;
    bool is_start = true;
    int conv_cnt;
    int effect_cnt;
    string[] conv_dialog = {"당신의 손에는 활과 화살이 들려있습니다.","활을 쏴 이시미를 사냥하시겠습니까?"};
    public GameObject intro_panel;
    public TMP_Text button_text;
    public TMP_Text center_text;
    public TMP_Text target_text;
    [SerializeField]
    float CharPerSec;

    void SetConvText(){
        if(conv_cnt == 0){
            target_text = center_text;
        }
        else if(conv_cnt == 1){
            intro_panel.SetActive(false);
            target_text = button_text;
        }
        else{
            return;
        }
        TextEffectStart();
    }
    void TextEffectStart(){
        soundManager.playTypingSound();
        target_text.text = "";
        effect_cnt=0;
        is_texteff = true;
        Invoke("TextEffecting",1/CharPerSec);
    }
    void TextEffecting(){
        if(effect_cnt==conv_dialog[conv_cnt].Length){
            TextEffectEnd();
            return;
        }
        target_text.text += conv_dialog[conv_cnt][effect_cnt];
        effect_cnt++;
        Invoke("TextEffecting",1/CharPerSec);
    }
    void TextEffectEnd(){
        soundManager.stopTypingSound();
        is_texteff = false;
        target_text.text = conv_dialog[conv_cnt];
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            if(is_start){
                is_start = false;
                conv_cnt=0;
                SetConvText();
            }
            else if(is_texteff){
                CancelInvoke();
                TextEffectEnd();
            }
            else{
                conv_cnt++;
                SetConvText();
            }
        }
    }
}
