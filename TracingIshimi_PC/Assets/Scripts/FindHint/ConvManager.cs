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
    private int[] conv_character;
    private string[] conv_dialog;

    void Awake(){
        //sprites_obj = new Sprite[obj_arrlen];
    }

    public void CallConversation(int[] conv_character, string[] conv_dialog, int sprite_idx){
        gameObject.SetActive(true);
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
        conv_text.text = conv_dialog[conv_cnt];
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            conv_cnt++;
            SetConvText();
        }
    }
}
