using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToLeft : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 10f;


    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
