using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    void Update()
    {
        if (!IsObjectBelow())
        {
            // 아래에 오브젝트가 없으면 파괴
            Destroy(this.gameObject);
        }
    }

    bool IsObjectBelow()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 5f, LayerMask.GetMask("Platform"));

        // 아래 방향으로 Ray를 발사하여 플랫폼 태그와 충돌하는지 확인

        // 충돌한 오브젝트의 태그가 플랫폼 태그와 일치하면 true 반환
        if (hit.collider != null)
        {
            return true;
        }
        else
            return false;
    }

}


