using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMotion : MonoBehaviour
{
    public float distance;
    public float speed;

    private Vector3 startPos;
    private bool facingRight = true;

    void Start()
    {
        startPos = this.transform.position;
    }

    void Update()
    {
        Vector3 pos = startPos;
        pos.x += distance * Mathf.Sin(Time.time * speed);
        transform.position = pos;

        // Check if direction has changed
        if (facingRight && pos.x < transform.position.x)
        {
            Flip();
            facingRight = false;
        }
        else if (!facingRight && pos.x > transform.position.x)
        {
            Flip();
            facingRight = true;
        }
    }

    // Flip the sprite
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
