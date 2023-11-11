using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVariance : MonoBehaviour
{
    public float startEventTime = 94f;
    public float spentTime = 0f;
    public float speed = 0.5f;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        spentTime += Time.deltaTime;
        if (spentTime > startEventTime)
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
