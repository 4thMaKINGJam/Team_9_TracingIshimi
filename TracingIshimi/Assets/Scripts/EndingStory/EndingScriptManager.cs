using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndingScriptManager : MonoBehaviour
{
    //10번은 플레이어, 20번은 산받이, 30번은 윗나레이션 40번은 아랫나레이션 50번 사운드
    public GameObject system_NPCconv;
    public GameObject system_Button;
    public GameObject system_end;
    public GameObject window_NPCname;
    public GameObject portrait_NPC;
    public GameObject image_obj;
    public GameObject image_end;
    public GameObject panel_end;
    public Sprite[] sprites_obj;
    public TMP_Text conv_text;
    public TMP_Text npc_text;
    public TMP_Text narrCenter_text;
    public TMP_Text narrDown_text;
    public TMP_Text END_text;
    public TMP_Text target_text;
    public bool is_shoot;
    private int conv_cnt = 0;
    private int effect_cnt;
    private bool is_texteff;
    private bool is_ending = false;
    private bool is_credit = false;
    private int[] conv_character;
    private string[] conv_dialog;
    private int[] sprite_idx;
    private int[] sound_idx;

    [SerializeField]
    float CharPerSec;

    public void CallConversation(int[] conv_character, string[] conv_dialog, int[] sprite_idx, int[] sound_idx){
        system_Button.SetActive(false);
        this.conv_character = conv_character;
        this.conv_dialog = conv_dialog;
        this.sprite_idx = sprite_idx;
        this.sound_idx = sound_idx;
        
        SetConvText();
        
    }

    void SetConvText(){
        END_text.text = "";
        if(conv_cnt>=conv_character.Length){
            Debug.Log(conv_cnt+"/"+conv_character.Length);
            if(!is_ending){
                CallEnding();
            }
            return;
        }
        
        // 중앙 그래픽
        if(sprite_idx[conv_cnt]==-1){
            image_obj.SetActive(false);
            
        }
        else{
            image_obj.SetActive(true);
            image_obj.GetComponent<Image>().sprite = sprites_obj[sprite_idx[conv_cnt]];
            image_obj.GetComponent<Image>().SetNativeSize();
        }

        // 사운드이펙트
        if(sound_idx[conv_cnt]!=-1){
            Debug.Log("SE: "+sound_idx[conv_cnt]);
        }
        else if(sound_idx[conv_cnt]==-2){
            Debug.Log("Main BGM Stop");
        }
        Debug.Log("Sound Done");

        
        // 대화
        if(conv_character[conv_cnt]==10){
            system_NPCconv.SetActive(true);
            window_NPCname.SetActive(false);
            portrait_NPC.SetActive(false);
            target_text = conv_text;
            narrCenter_text.text = "";
            narrDown_text.text = "";
        }
        else if(conv_character[conv_cnt]==20){
            system_NPCconv.SetActive(true);
            window_NPCname.SetActive(true);
            portrait_NPC.SetActive(true);
            target_text = conv_text;
            narrCenter_text.text = "";
            narrDown_text.text = "";
            npc_text.text = "산받이";
        }
        else if(conv_character[conv_cnt]==30){
            system_NPCconv.SetActive(false);
            narrDown_text.text = "";
            target_text = narrCenter_text;
        }
        else{
            system_NPCconv.SetActive(false);
            narrCenter_text.text = "";
            target_text = narrDown_text;
        }
        TextEffectStart();
    }

    void TextEffectStart(){
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
        if(sprite_idx[conv_cnt]==4){
                target_text.text +="<color=\"black\">"+conv_dialog[conv_cnt][effect_cnt]+"</color>";
        }
        else{
            target_text.text += conv_dialog[conv_cnt][effect_cnt];
        }
        effect_cnt++;
        Invoke("TextEffecting",1/CharPerSec);
    }
    void TextEffectEnd(){
        Debug.Log("TextEffect End");
        is_texteff = false;
        if(sprite_idx[conv_cnt]==4){
            target_text.text ="<color=\"black\">"+conv_dialog[conv_cnt]+"</color>";
        }
        else{
            target_text.text = conv_dialog[conv_cnt];
        }

    }

    void CallEnding(){
        is_ending = true;
        image_obj.SetActive(false);
        target_text = END_text;
        narrCenter_text.text = "";
        conv_dialog[--conv_cnt] = "「이시미잡이」";
        sprite_idx[conv_cnt] = -1;
        TextEffectStart();
        Invoke("showCHchar",1.3f);
        Invoke("showCredit",2);
    }

    void showCHchar(){
        image_end.SetActive(true);
    }

    void showCredit(){
        is_credit = true;
        image_end.SetActive(false);
        panel_end.SetActive(true);
        END_text.text = "제 4회 메이킹잼\n프로젝트 - 이시미잡이\n\n- 기획 -\n<color=\"grey\">한국음악과</color>\n한이새꽃\n\n- 그래픽 -\n<color=\"grey\">섬유예술과</color>\n이주원\n\n- 코더 -\n<color=\"grey\">컴퓨터공학전공</color>\n김정민\n\n김현민\n\n이소민";
        system_end.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,-1400f);
        panel_end.GetComponent<Image>().color = new Color(0,0,0,1);
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            if(!is_ending && conv_cnt<conv_character.Length){
                if(is_texteff){
                    CancelInvoke();
                    TextEffectEnd();
                }
                else{
                    conv_cnt++;
                    SetConvText();
                }   
            }
        }
        if(is_credit&&system_end.GetComponent<RectTransform>().anchoredPosition.y<=1200){
            if(panel_end.GetComponent<Image>().color.a>0){
                Color color = panel_end.GetComponent<Image>().color;
                panel_end.GetComponent<Image>().color = new Color(0,0,0, color.a -=0.005f);
            }
         float posY = system_end.GetComponent<RectTransform>().anchoredPosition.y;
         system_end.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,posY+1f);
        }
    }
}