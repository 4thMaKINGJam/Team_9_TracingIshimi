using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IshimiEvent : MonoBehaviour
{
    public float shakeDuration = 2f;
    public float shakeIntensity = 0.5f;

    private Vector3 originalPosition;
    public Camera camera;

    void Start()
    {
        originalPosition = camera.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float x = originalPosition.x + Mathf.PerlinNoise(Time.time * 10f, 0f) * shakeIntensity;
            float y = originalPosition.y + Mathf.PerlinNoise(0f, Time.time * 10f) * shakeIntensity;

            camera.transform.position = new Vector3(x, y, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Shake이 끝난 후 카메라를 초기 위치로 되돌립니다.
        camera.transform.position = originalPosition;
    }
}
