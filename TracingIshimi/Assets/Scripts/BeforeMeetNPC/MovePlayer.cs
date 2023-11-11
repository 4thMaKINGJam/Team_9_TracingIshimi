using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private float moveSpeed = 3f;
    int num;
    public float time;

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        num = (int)time;

        transform.position += Vector3.right * moveSpeed *Time.deltaTime;

        if (transform.position.x > 18.54) {
            moveSpeed = 0;
        }

        if (num >= 16) {
            moveSpeed = 3f;
            transform.position += Vector3.right * moveSpeed *Time.deltaTime;
        }

        if (num >= 19) {
            moveSpeed = 0;
        }
        
    }
}
