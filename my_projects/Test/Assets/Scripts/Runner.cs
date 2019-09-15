using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : DebugClass
{
    public GameObject player;
    public float speed = 20f;
    public float step = 0.1f;

    private Rigidbody2D player_body;

    private float timer = 0f;
    private Vector2 player_pos;

    void Start()
    {
        player_body = player.GetComponent<Rigidbody2D>();
        player_pos = transform.position;
        // debug_print("Start");
    }

    void Update()
    {
        timer += speed * Time.deltaTime;
        if(timer >= 1f)
        {
            // debug_print("Update " + player_pos.x);
            timer = 0f;
            player_pos.x+=step;

            player_body.MovePosition(player_pos);
        }        
    }
}
