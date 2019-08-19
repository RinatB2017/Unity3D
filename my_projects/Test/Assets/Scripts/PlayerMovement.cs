using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMove = 0f;
    float verticalMove = 0f;

    public float runSpeed = 40f;

    private Vector2 old_position;
    private Vector2 new_position;

    public Rigidbody2D rigidbody2D;
    public Joystick joystick;

    void Start()
    {
        old_position = new Vector2(0, 0);
        new_position = new Vector2(0, 0);        
    }

    void test()
    {
        horizontalMove = joystick.Horizontal * runSpeed;
        verticalMove = joystick.Vertical * runSpeed;

        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = joystick.Horizontal * runSpeed;
        } else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = joystick.Horizontal * -runSpeed;
        } else
        {
            horizontalMove = 0f;
        }
        
        if (joystick.Vertical >= .2f)
        {
            verticalMove = joystick.Vertical * runSpeed;
        } else if (joystick.Vertical <= -.2f)
        {
            verticalMove = joystick.Vertical * -runSpeed;
        } else
        {
            verticalMove = 0f;
        }
    }

    void Update()
    {
        horizontalMove = joystick.Horizontal * runSpeed;
        verticalMove = joystick.Vertical * runSpeed;

        new_position.x = horizontalMove;
        new_position.y = verticalMove;

        rigidbody2D.MovePosition(new_position);
    }
}
