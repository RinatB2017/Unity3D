using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceMove : MonoBehaviour
{
    public float speed = 2.0f;
    public bool dir_right = false;
    public float min_x = -5f;
    public float max_x = 5f;

    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("triggered " + other);
    }

    void Update()
    {
        Vector2 position = rigidbody2D.position;
        if(position.x <= min_x)
        {
            dir_right = true;
        }
        if(position.x >= max_x)
        {
            dir_right = false;
        }
        if(dir_right)
            position.x = position.x + Time.deltaTime * speed;
        else
            position.x = position.x - Time.deltaTime * speed;

        rigidbody2D.MovePosition(position);
    }
}
