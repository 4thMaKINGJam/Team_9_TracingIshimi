using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public float startEventTime = 100f;
    public float speed = 10f;
    public bool isStop = true;
    public float spentTime = 0f;

    // Update is called once per frame
    void Update()
    {
        spentTime += Time.deltaTime;
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (spentTime > startEventTime && isStop)
        {
            speed = 0;
        }
    }
}
