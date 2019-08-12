using UnityEngine;
using System.Collections;

public class Btn_fire : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 10f;

    void OnMouseDown()
    {
        Debug.Log("down");
    }
}
