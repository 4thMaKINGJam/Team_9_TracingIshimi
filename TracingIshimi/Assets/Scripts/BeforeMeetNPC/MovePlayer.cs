using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private float moveSpeed = 3f;
    int num;
    public float time;
    public Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        num = (int)time;

        transform.position += Vector3.right * moveSpeed *Time.deltaTime;

        if (transform.position.x > 18.54) {
            moveSpeed = 0;
            anim.SetBool("isWalk", false);
        }

        if (num >= 16) {
            anim.SetBool("isWalk", true);
            moveSpeed = 3f;
            transform.position += Vector3.right * moveSpeed *Time.deltaTime;
        }

        if (num >= 19) {
            moveSpeed = 0;
            transform.position += Vector3.right * moveSpeed *Time.deltaTime;
        }
        
    }
}
