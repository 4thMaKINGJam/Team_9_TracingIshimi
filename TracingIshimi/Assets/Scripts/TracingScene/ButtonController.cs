using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer btnSpriteRenderer;
    private Color originalColor;
    public GameObject jumpBtn; //플레이어 오브젝트

    void Start()
    {
        btnSpriteRenderer = jumpBtn.GetComponent<SpriteRenderer>();
        originalColor = btnSpriteRenderer.color;
    }
    public void onClickDownJump()
    {
        StartCoroutine(MakeBtnVincible());
    }


    IEnumerator MakeBtnVincible()
    {
        btnSpriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);

        // 일정 시간 기다리기
        yield return new WaitForSeconds(1f);

        // 플레이어를 다시 불투명하게 만들기
        btnSpriteRenderer.color = originalColor;

    }
}
