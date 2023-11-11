using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStarter : MonoBehaviour
{
    AudioSource objAudio;
    // Start is called before the first frame update
    void Start()
    {
        objAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objAudio.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objAudio.Play();
        }
    }

}

