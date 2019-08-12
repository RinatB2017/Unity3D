using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rigidbody2D;

    public void move_left(float value)
    {
        Vector2 position = transform.position;
        position.x = position.x - speed * value * Time.deltaTime;
    }

    public void move_right(float value)
    {
        Vector2 position = transform.position;
        position.x = position.x + speed * value * Time.deltaTime;

        rigidbody2D.MovePosition(position);
    }

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal != 0f || vertical != 0f) {
            Vector2 position = transform.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;

            //Debug.Log("position.x " + position.x);

            //transform.position = position;
            rigidbody2D.MovePosition(position);
        }
    }
}
