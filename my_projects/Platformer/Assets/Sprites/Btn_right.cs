using UnityEngine;
using System.Collections;

public class Btn_right : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 10f;

    void OnMouseDown()
    {
        Vector2 position = transform.position;
        //position.x = position.x + speed * Time.deltaTime;
        position.x = position.x + speed;

        Debug.Log("position.x " + position.x);

        player.MovePosition(position);
    }
}
