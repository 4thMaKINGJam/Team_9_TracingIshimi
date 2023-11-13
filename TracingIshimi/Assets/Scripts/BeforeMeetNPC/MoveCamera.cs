using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] MovePlayer playerscript;
    [SerializeField] float smoothing = 0.2f;
    [SerializeField] Vector2 minCameraBoundary;
    [SerializeField] Vector2 maxCameraBoundary;
    private float moveSpeed = 3f;
    int num;
    public float time;

    void awake(){
        MovePlayer playerscript = GetComponent<MovePlayer>();
    }
    private void FixedUpdate(){
        time += Time.deltaTime;
        num = (int)time;
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);

        targetPos.x = Mathf.Clamp(targetPos.x, minCameraBoundary.x, maxCameraBoundary.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minCameraBoundary.y, maxCameraBoundary.y);

        if (player.position.x <= 18.53) {
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }

        else if (player.position.x > 18.53 && transform.position.x <= 23.72) {
            transform.position += Vector3.right * moveSpeed *Time.deltaTime;
        }

        else {
            moveSpeed = 0;
        }

        if (num >= 16) {
            playerscript.anim.SetBool("isWalk", true);
            moveSpeed = 3f;
            transform.position += Vector3.right * moveSpeed *Time.deltaTime;
        }

        if (num >= 19) {
            moveSpeed = 0;
            transform.position += Vector3.right * moveSpeed *Time.deltaTime;
        }



    }
    
}