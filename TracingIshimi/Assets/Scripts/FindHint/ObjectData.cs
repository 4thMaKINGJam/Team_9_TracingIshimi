using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectData : MonoBehaviour,IPointerClickHandler
{
    public int obj_id;
    public GameObject object_manager;
    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("ClickHandler");
        
        object_manager.GetComponent<ObjectManager>().ChangeShadowColor(obj_id);
        
    }
}
