using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//캐릭터는 가만히 있고 배경이 왼쪽으로 움직임. 
public class GroundMovingToLeft : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);

    }
}
