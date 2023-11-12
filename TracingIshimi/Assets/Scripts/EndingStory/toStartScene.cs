using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class toStartScene : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData){
        SceneManager.LoadScene("TitleScene");
    }
}
