using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] obj_original;
    public GameObject[] obj_shadow;
    private void Awake(){
        for(int i = 0; i<obj_original.Length;i++){
            obj_original[i].GetComponent<ObjectData>().obj_id = i;
        }
    }
    public void ChangeShadowColor(int idx){
        Image shadow_image = obj_shadow[idx].GetComponent<Image>();
        shadow_image.color = new Color(1,1,1,1);
    }
}
