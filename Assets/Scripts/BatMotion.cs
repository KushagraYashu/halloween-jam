using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMotion : MonoBehaviour
{
    public float distance;
    public float speed;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = startPos;
        pos.x += distance * Mathf.Sin(Time.time * speed);
        transform.position = pos;
    }
}
