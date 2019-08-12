using UnityEngine;
using System.Collections;

public class Btn_left : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 1f;

    private bool flag = false;

    void OnMouseDown()
    {
        flag = true;
    }

    void OnMouseUp()
    {
        flag = false;
    }

    void Update()
    {
        if(flag) 
        {
            Vector2 position = player.transform.position;
            //Debug.Log("position.x " + position.x);

            //position.x = position.x - speed * Time.deltaTime;
            position.x = position.x - speed;

            //Debug.Log("position.x " + position.x);

            player.MovePosition(position);
        }
    }
}
