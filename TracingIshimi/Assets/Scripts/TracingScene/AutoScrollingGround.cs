
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//캐릭터는 가만히 있고 배경이 왼쪽으로 움직임. 
public class AutoScrollingGround : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private float length = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;
        if (this.GetComponent<SpriteRenderer>().enabled)
        {
            length = this.GetComponent<SpriteRenderer>().sprite.bounds.size.x; //백그라운드의 크기
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= -length * 3)
        {
            Reposition();
        }
    }
    private void Reposition()
    {
        Vector3 offset = new Vector3(length * 8f, 0, 0);
        transform.position = (Vector3)transform.position + offset;
    }
}
