using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    GameObject Player; //플레이어 오브젝트
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerController = Player.GetComponent<PlayerController>();
    }

    public void jump_btnDown()
    {
        playerController.isJumpBtnDown = true;
    }

    public void jump_btnUp()
    {
        playerController.isJumpBtnDown = false;
    }
}
