using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;

    // Start is called before the first frame update

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private AudioSource audioSource;
    public AudioClip audioHurt;
    public PlayerController playerController;
    private bool isSuper = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = audioHurt;
        audioSource.loop = false;
        playerController = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Obstacle") && !isSuper)
        {
            StartCoroutine(MakePlayerSuper());
            audioSource.Play();
            currentHealth--;
            if (currentHealth == 0)
            {
                playerController.SetPlayerStateDie();
            }
        }
    }
    IEnumerator MakePlayerSuper()
    {

        isSuper = true;
        // 일정 시간 기다리기
        yield return new WaitForSeconds(2.0f);

        isSuper = false;


    }
}
