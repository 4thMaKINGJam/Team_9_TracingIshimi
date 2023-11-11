using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectData : MonoBehaviour,IPointerClickHandler
{
    public int obj_id;
    public GameObject object_manager;
    public FindHintSoundManager soundManager;

    [SerializeField]
    int[] conv_character;
    [SerializeField]
    string[] conv_dialog;
    Dictionary<int, string[]> conv_data;

    public void OnPointerClick(PointerEventData eventData){
        soundManager.playSoundEffect("pickup");
        object_manager.GetComponent<ObjectManager>().ObjectFind(obj_id,conv_character,conv_dialog);
        gameObject.SetActive(false);
    }
}
