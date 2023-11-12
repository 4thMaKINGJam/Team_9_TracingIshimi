using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack2 : MonoBehaviour
{
    private float moveSpeed = 3f;
    
    public float time;
    int num;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        num = (int)time;

        if (num >= 27){
            transform.position += Vector3.up * moveSpeed *Time.deltaTime;
            if (transform.position.y > 0) {
                moveSpeed = 0;
            }
        }
    }
}
