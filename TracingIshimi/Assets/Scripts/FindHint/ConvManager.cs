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
    public Sprite[] sprites_obj;
    public TMP_Text conv_text;
    public TMP_Text npc_text;
    private int conv_cnt =0;
    private int progress_cnt = 0;
    private int effect_cnt;
    private bool is_texteff;
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
        conv_text.text = "";
        effect_cnt=0;
        is_texteff = true;
        Invoke("TextEffecting",1/CharPerSec);
    }
    void TextEffecting(){
        if(conv_text.text==conv_dialog[conv_cnt]){
            TextEffectEnd();
            return;
        }
        conv_text.text += conv_dialog[conv_cnt][effect_cnt];
        effect_cnt++;
        Invoke("TextEffecting",1/CharPerSec);
    }
    void TextEffectEnd(){
        is_texteff = false;
        conv_text.text = conv_dialog[conv_cnt];
        if(progress_cnt==obj_arrlen && conv_cnt == conv_dialog.Length-1){
            Invoke("toNextStage",2);
        }
    }

    void toNextStage(){
        Debug.Log("Stage SUCCESS : To Next Stage");
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
