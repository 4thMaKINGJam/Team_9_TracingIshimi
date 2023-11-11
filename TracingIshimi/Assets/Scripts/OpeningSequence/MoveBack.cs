using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    private float moveSpeed = 2f;

    // Update is called once per frame
    void Update()
    {

        while (transform.position.y != 0) {
            transform.position += Vector3.up * moveSpeed *Time.deltaTime;
        }
    }
}
