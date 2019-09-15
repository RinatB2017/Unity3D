using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DebugClass
{
    public Rigidbody2D player;
    public float speed = 0.1f;
    private Vector2 old_position;
    private Vector2 new_position;

    void left()
    {
        new_position.x = new_position.x - speed;
    }

    void right()
    {
        new_position.x = new_position.x + speed;
    }

    void up()
    {
        new_position.y = new_position.y + speed;
    }

    void down()
    {
        new_position.y = new_position.y - speed;
    }

    void kill()
    {
        Destroy(this.gameObject);
    }

    void Awake()
    {
        old_position = new Vector2(0, 0);
        new_position = new Vector2(0, 0);
    }

    void Update()
    {
        if(old_position != new_position)
        {
            old_position = new_position;
            player.MovePosition(new_position);
            //player.AddForce(new_position);
        }        
    }
}
