using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Rigidbody2D gameObject;
    public float speed = 200f;

    public GameObject sprite_R;
    public GameObject sprite_G;
    public GameObject sprite_B;

    private Camera cam;

    private int s_width = 0;
    private int s_height = 0;

    public int PPU = 100;
    float w_sprite = 1024;
    float h_sprite = 768;

    void debug_print(string text)
    {
        //print(text);
    }

    void Awake()
    {
        cam = Camera.main;

        Vector3 screenPos = cam.WorldToScreenPoint(new Vector3(0, 0, 0));
        debug_print("screenPos: " + screenPos);

        s_width  = Screen.width;
        s_height = Screen.height;
        debug_print("width  " + s_width);
        debug_print("height " + s_height);
        debug_print("X: " + transform.position.x);
    }

    void Start()
    {

    }

    void move()
    {
        Vector2 position = transform.position;
        position.y += speed * Time.deltaTime;
        gameObject.MovePosition(position);
    }

    void Update()
    {

    }
}
