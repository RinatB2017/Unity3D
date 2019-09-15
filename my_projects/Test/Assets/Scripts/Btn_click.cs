using UnityEngine;
using System.Collections;

public class Btn_click : DebugClass
{
    public GameObject gameObject;
    public string f_name;

    //---
    // private GameObject player;
    // private Rigidbody2D p_body;
    // private Vector2 p_pos;
    //---

    void Awake()
    {
        // if (player == null)
        //     player = GameObject.FindWithTag("Player");

        // p_body = player.GetComponent<Rigidbody2D>();
        // p_pos = player.transform.position;
    }
    
    void OnMouseDown()
    {
        debug_print("DOWN: " + f_name);
        // if(f_name == "f_up")
        // {
        //     p_pos.y-=0.1f;
        //     p_body.MovePosition(p_pos);
        // }
        // if(f_name == "f_down")
        // {
        //     p_pos.y+=0.1f;
        //     p_body.MovePosition(p_pos);
        // }
        // player.SendMessage(f_name, true);
        gameObject.SendMessage(f_name, true);
        //p_pos.y--;
        //p_body
    }

    void OnMouseUp()
    {
        // player.SendMessage(f_name, false);
        gameObject.SendMessage(f_name, false);
    }
}
