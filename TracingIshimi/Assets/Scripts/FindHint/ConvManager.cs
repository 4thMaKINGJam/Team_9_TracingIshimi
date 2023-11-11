using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConvManager : MonoBehaviour
{
    //10번은 플레이어, 20번은 산받이
    public int obj_arrlen;
    public GameObject window_NPCname;
    public GameObject portrait_NPC;
    public GameObject image_obj;
    public GameObject system_nextStage;
    public Sprite[] sprites_obj;
    public TMP_Text conv_text;
    public TMP_Text npc_text;
    public TMP_Text center_text;
    public TMP_Text target_text;
    private int conv_cnt =0;
    private int progress_cnt = 0;
    private int effect_cnt;
    private bool is_texteff;
    private bool is_next = false;
    private int[] conv_character;
    private string[] conv_dialog;

    [SerializeField]
    float CharPerSec;

    void Awake(){
        //sprites_obj = new Sprite[obj_arrlen];
    }

    public void CallConversation(int[] conv_character, string[] conv_dialog, int sprite_idx){
        gameObject.SetActive(true);
        progress_cnt++;
        this.conv_character = conv_character;
        this.conv_dialog = conv_dialog;
        image_obj.GetComponent<Image>().sprite = sprites_obj[sprite_idx];
        image_obj.GetComponent<Image>().SetNativeSize();
        SetConvText();
    }

    void SetConvText(){
        target_text = conv_text;
        if(is_next){
            target_text = center_text;
        }
        if(conv_cnt==conv_character.Length){
            gameObject.SetActive(false);
            conv_cnt = 0;
            return;
        }
        if(conv_character[conv_cnt]==20){
                window_NPCname.SetActive(true);
                portrait_NPC.SetActive(true);
                npc_text.text = "산받이";
        }
        else{
            window_NPCname.SetActive(false);
            portrait_NPC.SetActive(false);
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
        if(target_text.text==conv_dialog[conv_cnt]){
            TextEffectEnd();
            return;
        }
        target_text.text += conv_dialog[conv_cnt][effect_cnt];
        effect_cnt++;
        Invoke("TextEffecting",1/CharPerSec);
    }
    void TextEffectEnd(){
        is_texteff = false;
        target_text.text = conv_dialog[conv_cnt];
        if(!is_next && progress_cnt==obj_arrlen && conv_cnt == conv_dialog.Length-1){
            Invoke("toNextStage",2);
        }
    }

    void toNextStage(){
        Debug.Log("Stage SUCCESS : To Next Stage");
        gameObject.SetActive(true);
        system_nextStage.SetActive(true);
        is_next = true;
        int[] tmp_character = {10,10};
        this.conv_character = tmp_character;
        string[] next_dialog = {"이시미의 비늘이 떨어진 방향의 길로 발걸음을 옮긴다.","아니나 다를까, 바닥에는 거대한 뱀이 지나간 듯한 흔적이 이어진다."};
        this.conv_dialog = next_dialog;
        Debug.Log(conv_cnt);
        SetConvText();
        
    }
    void Update(){
        if(Input.GetMouseButtonDown(0)){
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
