using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Jump,
        Die,
        Idle, //Idle = 뛰기
        Hurt //다쳣을때 깜빡거림
    }


    public GameObject ImageRestart;

    //[SerializeField] private Button jumpBtn;
    [SerializeField] private float jumpForce = 10f;
    public int jumpCount = 0; //private로 후에 수정
    Rigidbody2D playerRigid;
    public PlayerState playerState;

    public float fallGravityScale = 4f;

    public bool isJumpBtnDown = false;
    Animator anim;

    AudioSource jumpAudio;

    private AudioSource audioSource;
    public AudioClip audioBgm;
    // Start is called before the first frame update
    private SpriteRenderer playerSpriteRenderer;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = audioBgm;
        audioSource.loop = false;
        audioSource.Play();

        playerState = PlayerState.Idle;
        playerRigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpAudio = GetComponent<AudioSource>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == PlayerState.Die)
        {
            anim.SetBool("isDie", true);
        }
        //if (isJumpBtnDown)
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (playerState == PlayerState.Jump && playerRigid.velocity.y < 0)
        {
            playerRigid.gravityScale = fallGravityScale;
        }
        else
        {
            playerRigid.gravityScale = 2f; // 원래 중력 스케일로 복원
        }
    }

    public void SetPlayerStateDie()
    {
        playerState = PlayerState.Die;
        this.gameObject.layer = 9;
        playerRigid.constraints = RigidbodyConstraints2D.None;
        playerRigid.AddForce(new Vector2(-1, 1) * 7, ForceMode2D.Impulse);
        StartCoroutine(SlowDownTime(2.0f)); // 3초 동안 시간을 천천히 멈춤

        // 여기서 다른 작업 수행 가능
    }

    private IEnumerator SlowDownTime(float duration)
    {
        float targetTimeScale = 0f; // 원하는 타임 스케일 값 (0에 가까울수록 더 천천히 정지됨)
        float currentTimeScale = Time.timeScale;
        float startTime = Time.realtimeSinceStartup;

        audioSource.Stop();
        ImageRestart.SetActive(true);
        while (Time.realtimeSinceStartup - startTime < duration)
        {
            float t = (Time.realtimeSinceStartup - startTime) / duration;
            Time.timeScale = Mathf.SmoothStep(currentTimeScale, targetTimeScale, t);
            yield return null;
        }

        Time.timeScale = targetTimeScale; // 정확하게 0으로 맞추기 위해 마지막에 설정

    }




    public void Jump()
    {
        if (this.jumpCount < 2)
        {
            jumpSound();
            anim.SetInteger("jumpCount", ++jumpCount);
            playerRigid.velocity = Vector2.zero;
            playerRigid.velocity = new Vector2(0, jumpForce);
            playerState = PlayerState.Jump;
        }
    }

    public void jumpSound()
    {
        jumpAudio.Play();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Obstacle") && playerState != PlayerState.Hurt)
        {
            playerState = PlayerState.Hurt;
            StartCoroutine(MakePlayerInvincible());
        }
        else if (col.gameObject.CompareTag("Border"))
        {
            playerState = PlayerState.Die;

            SetPlayerStateDie();
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
            anim.SetInteger("jumpCount", jumpCount);
            playerState = PlayerState.Idle;
        }
    }

    IEnumerator MakePlayerInvincible()
    {

        // 플레이어를 투명하게 만들기
        Color originalColor = playerSpriteRenderer.color;
        playerSpriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.8f);

        // 일정 시간 기다리기
        yield return new WaitForSeconds(3.0f);

        // 플레이어를 다시 불투명하게 만들기
        playerSpriteRenderer.color = originalColor;

        playerState = PlayerState.Idle;


    }
}
