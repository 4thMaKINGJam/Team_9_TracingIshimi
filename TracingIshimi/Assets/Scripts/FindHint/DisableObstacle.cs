using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableObstacle : MonoBehaviour,IPointerClickHandler
{
    public GameObject obstacle_after;
    public FindHintSoundManager soundManager;
    public string sound_eff;

    public void OnPointerClick(PointerEventData eventData){
        soundManager.playSoundEffect(sound_eff);
        gameObject.SetActive(false);
        obstacle_after.SetActive(true);
    }
}
