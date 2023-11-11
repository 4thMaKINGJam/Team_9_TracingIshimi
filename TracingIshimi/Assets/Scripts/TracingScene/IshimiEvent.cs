using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IshimiEvent : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 0.2f;
    private Vector3 initialPosition;
    // Update is called once per frame

    void awake()
    {
        initialPosition = transform.position;
    }
    void Update()
    {

        initialPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.5f;
            StartCoroutine(Shake());
        }
    }

    private IEnumerator Shake()
    {
        while (true)
        {
            //만약 좌우로 움직이게 하고 싶으면
            float newX = initialPosition.x + Mathf.Sin(Time.time * speed) * distance; //: transform.position.x;
            //만약 상하로 움직이게 하고 싶으면
            float newY = initialPosition.y + Mathf.Sin(Time.time * speed) * distance;//: transform.position.y;
            transform.position = new Vector3(newX, newY, transform.position.z);
            yield return null;
        }

    }
}
