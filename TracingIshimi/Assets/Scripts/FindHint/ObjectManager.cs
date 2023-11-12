using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    public GameObject system_conv;
    public GameObject[] obj_original;
    public GameObject[] obj_shadow;
    public Sprite[] obj_sprites;
    int[] conv_character;
    string[] conv_dialog;
    int idx;

    private void Awake(){
        for(int i = 0; i<obj_original.Length;i++){
            obj_original[i].GetComponent<ObjectData>().obj_id = i;
        }
        system_conv.GetComponent<ConvManager>().obj_arrlen = obj_original.Length;
    }
    public void ObjectFind(int idx, int[] conv_character, string[] conv_dialog){
        Image shadow_image = obj_shadow[idx].GetComponent<Image>();
        this.conv_character = conv_character;
        this.conv_dialog = conv_dialog;
        this.idx = idx;
        shadow_image.sprite = obj_sprites[idx];
        Invoke("CallConvManager",0.5f);
    }
    void CallConvManager(){
        system_conv.GetComponent<ConvManager>().CallConversation(conv_character,conv_dialog,idx);
    }
}
