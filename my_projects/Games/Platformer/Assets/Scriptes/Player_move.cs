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

    void click_left(bool state)
    {
        f_left = state;
    }
    void click_right(bool state)
    {
        f_right = state;
    }
    void click_up(bool state)
    {
        f_up = state;
    }
    void click_down(bool state)
    {
        f_down = state;
    }

    void click(int ID, int state)
    {
        switch (ID)
        {
            case 1: f_left = (state != 0) ? true : false;  break;
            case 2: f_right = (state != 0) ? true : false; break;
            case 3: f_up = (state != 0) ? true : false;    break;
            case 4: f_down = (state != 0) ? true : false;  break;
            default:
                break;
        }
    }

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
