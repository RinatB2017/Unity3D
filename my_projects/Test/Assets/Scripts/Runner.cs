using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : DebugClass
{
    public GameObject player;
    public float speed = 20f;
    public float h_step = 0.1f;
    public float v_step = 0.01f;

    // public List<TestClass> l_test;
    // public TestClass l_test;

    private Rigidbody2D player_body;

    private float timer = 0f;
    private Vector2 player_pos;

    //---
    // public GameObject[] players;
    // public GameObject f_player;
    //---

    void Start()
    {
        player_body = player.GetComponent<Rigidbody2D>();
        player_pos = transform.position;
        // debug_print("Start");

        // players = GameObject.FindGameObjectsWithTag("Player");
        // if(players.Length > 0)
        // {
        //     debug_print("YES");
        // }
        // f_player = GameObject.FindWithTag("Player");
        // if(f_player != null)
        // {
        //     debug_print("FIND!");
        // }
    }

    void kill()
    {
        debug_print("KILL");
    }

    void f_up()
    {
        // debug_print("f_up");
        player_pos.y+=v_step;
    }
    void f_down()
    {
        // debug_print("f_down");
        player_pos.y-=v_step;
    }

    void Update()
    {
        timer += speed * Time.deltaTime;
        if(timer >= 1f)
        {
            // debug_print("Update " + player_pos.x);
            timer = 0f;
            player_pos.x+=h_step;

            player_body.MovePosition(player_pos);
        }        
    }
}
