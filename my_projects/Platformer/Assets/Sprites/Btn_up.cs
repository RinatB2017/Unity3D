using UnityEngine;
using System.Collections;

public class Btn_up : MonoBehaviour
{
    public Rigidbody2D player;
    //public float speed = 1f;

    //private bool flag = false;

    //---
    void OnMouseDown()
    {
        //flag = true;
        player.gameObject.SendMessage("btn_up_down");
    }

    void OnMouseUp()
    {
        //flag = false;
        player.gameObject.SendMessage("btn_up_up");
    }
    //---

    // void Update()
    // {
    //     if(flag) 
    //     {
    //         Vector2 position = player.transform.position;
    //         position.y = position.y + speed;
    //         player.MovePosition(position);
    //     }
    // }
}
