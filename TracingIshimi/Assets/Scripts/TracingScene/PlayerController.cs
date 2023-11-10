using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        FirstJump,
        SecondJump,
        Damaged,
        Idle //Idle = 뛰기
    }


    //[SerializeField] private Button jumpBtn;
    [SerializeField] private float jumpForce = 10f;
    public int jumpCount = 0; //private로 후에 수정
    Rigidbody2D playerRigid;
    public PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerState.Idle;
        playerRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (this.jumpCount < 2)
        {
            jumpCount++;
            playerRigid.velocity = Vector2.zero;
            playerRigid.velocity = new Vector2(0, jumpForce);
            playerState = (jumpCount == 2) ? PlayerState.SecondJump : PlayerState.FirstJump;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
            playerState = PlayerState.Idle;
        }
    }
}
