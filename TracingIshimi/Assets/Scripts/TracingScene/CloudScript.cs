using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    void Start()
    {
        // 시작한 후 10초 뒤에 DeleteObject 메서드를 호출
        Invoke("DeleteObject", 10f);
    }

    void DeleteObject()
    {
        // 여기에 원하는 삭제 코드를 작성
        Destroy(gameObject);
    }
}