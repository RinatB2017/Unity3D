using UnityEngine;
using System.Collections;

public class Btn_right : MonoBehaviour
{
    public Rigidbody2D player;
    //public float speed = 1f;

    //private bool flag = false;

    //---
    void OnMouseDown()
    {
        //flag = true;
        player.gameObject.SendMessage("btn_right_down");
    }

    void OnMouseUp()
    {
        //flag = false;
        player.gameObject.SendMessage("btn_right_up");
    }
    //---

    // void Update()
    // {
    //     if(flag) 
    //     {
    //         Vector2 position = player.transform.position;
    //         position.x = position.x + speed;
    //         player.MovePosition(position);
    //     }
    // }
}
