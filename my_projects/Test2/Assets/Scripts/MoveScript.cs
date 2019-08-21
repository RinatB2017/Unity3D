using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Rigidbody2D gameObject;
    public float speed = 200f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 position = transform.position;
        position.y += speed * Time.deltaTime;
        gameObject.MovePosition(position);
    }
}
