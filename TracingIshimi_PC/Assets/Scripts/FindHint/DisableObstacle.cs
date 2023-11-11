using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableObstacle : MonoBehaviour,IPointerClickHandler
{
    public GameObject obstacle_after;
    public void OnPointerClick(PointerEventData eventData){
        gameObject.SetActive(false);
        obstacle_after.SetActive(true);
    }
}
