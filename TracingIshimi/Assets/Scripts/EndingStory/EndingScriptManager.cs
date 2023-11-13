using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndingScriptManager : MonoBehaviour
{
    public EndingStorySoundManager soundManager;
    //10번은 플레이어, 20번은 산받이, 30번은 윗나레이션 40번은 아랫나레이션 50번 사운드
    public GameObject system_NPCconv;
    public GameObject system_Button;
    public GameObject system_end;
    public GameObject window_NPCname;
    public GameObject portrait_NPC;
    public GameObject image_obj;
    public GameObject image_end;
    public GameObject panel_end;
    public GameObject system_credit;
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
    private bool bgm_paused = false;
    private int[] conv_character;
    private string[] conv_dialog;
    private int[] sprite_idx;
    private int[] sound_idx;

    [SerializeField]
    float CharPerSec;
    [SerializeField]
    string[] sound_eff;

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
        if(sound_idx[conv_cnt]==0){
            if(bgm_paused){
                bgm_paused = false;
                soundManager.resumeBGM();
            }
            else if(is_shoot){
                soundManager.playBGM("hunt_or_not");
            }
            else{
                soundManager.playBGM("not_shoot_bgm");
            }
        }
        else if(sound_idx[conv_cnt]==-2){
            bgm_paused = true;
            soundManager.pauseBGM();
        }
        else if(sound_idx[conv_cnt]!=-1){
            soundManager.playSoundEffect(sound_eff[sound_idx[conv_cnt]]);
        }

        
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
        if(sound_idx[conv_cnt]<=0)
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
        soundManager.stopTypingSound();
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
        system_end.SetActive(true);
        soundManager.fadeoutEffect();
        image_obj.SetActive(false);
        target_text = END_text;
        narrCenter_text.text = "";
        conv_dialog[--conv_cnt] = "「이시미잡이」";
        sprite_idx[conv_cnt] = -1;
        soundManager.playBGM("credit_bgm");
        TextEffectStart();
        Invoke("showCHchar",1.3f);
        Invoke("showCredit",3);
    }

    void showCHchar(){
        image_end.SetActive(true);
    }

    void showCredit(){
        system_credit.SetActive(true);
        system_credit.GetComponent<Credit>().showCredit();
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
        
    }
}