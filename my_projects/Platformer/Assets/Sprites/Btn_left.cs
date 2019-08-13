using UnityEngine;
using System.Collections;

public class Btn_left : MonoBehaviour
{
    public Rigidbody2D player;
    //public float speed = 1f;

    //private bool flag = false;

    //---
    void OnMouseDown()
    {
        //flag = true;
        player.gameObject.SendMessage("btn_left_down");
    }

    void OnMouseUp()
    {
        //flag = false;
        player.gameObject.SendMessage("btn_left_up");
    }
    //---

    // void Update()
    // {
    //     if(flag) 
    //     {
    //         Vector2 position = player.transform.position;
    //         position.x = position.x - speed;
    //         player.MovePosition(position);
    //     }
    // }
}
