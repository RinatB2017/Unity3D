using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float speed = 0.1f;
    public float h_speed = 10f;

    public Rigidbody2D rigidbody2D;

    private bool f_left  = false;
    private bool f_right = false;
    private bool f_up    = false;
    private bool f_down  = false;

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

    //---
    void btn_left_up()
    {
        f_left = false;
        print("btn_left_up");
    }

    void btn_left_down()
    {
        f_left = true;
        print("btn_left_down");
    }

    void btn_right_up()
    {
        f_right = false;
        print("btn_right_up");
    }

    void btn_right_down()
    {
        f_right = true;
        print("btn_right_down");
    }

    void btn_up_up()
    {
        f_up = false;
        print("btn_up_up");
    }

    void btn_up_down()
    {
        f_up = true;
        print("btn_up_down");
    }

    void btn_down_up()
    {
        f_down = false;
        print("btn_down_up");
    }

    void btn_down_down()
    {
        f_down = true;
        print("btn_down_down");
    }
    //---

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 position = transform.position;
        if(f_left)  position.x = position.x - speed;
        if(f_right) position.x = position.x + speed;
        if(f_up)    position.y = position.y + speed;
        if(f_down)  position.y = position.y - speed;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal < 0) position.x = position.x - speed;
        if(horizontal > 0) position.x = position.x + speed;
        if(vertical < 0)   position.y = position.y + speed;
        if(vertical > 0)   position.y = position.y - speed;

        rigidbody2D.MovePosition(position);
    }

    void Update2()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal != 0f || vertical != 0f) {
            Vector2 position = transform.position;
            position.x = position.x + h_speed * horizontal * Time.deltaTime;
            position.y = position.y + h_speed * vertical * Time.deltaTime;
            rigidbody2D.MovePosition(position);
        }
    }
}
